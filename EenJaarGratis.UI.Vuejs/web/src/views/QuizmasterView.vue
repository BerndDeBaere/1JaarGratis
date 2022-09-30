<template>
  <b-container>
    <div class="question-navigation-container mt-1">
      <b-button @click="previousQuestion" variant="outline-secondary">Vorige</b-button>
      <b-button-group>
        <b-button @click="reloadScoreboard" variant="outline-secondary">Scorebord</b-button>
        <b-button v-if="!showQuestionState" @click="showQuestion" variant="outline-secondary">Toon</b-button>
        <b-button v-if="showQuestionState" @click="hideQuestion" variant="outline-secondary">Verberg</b-button>
        <b-button @click="selectPlayers" variant="outline-secondary">selectPlayers</b-button>
      </b-button-group>
      <b-button @click="nextQuestion" variant="outline-secondary">Volgende</b-button>
    </div>
    <h1 v-if="question === undefined">Klik op vorige!</h1>
    <h1 v-if="question !== undefined">{{ question?.order + 1 }}) {{ question?.question }}</h1>
    <ul v-if="question !== undefined" class="list-group">
      <li class="list-group-item" :class="{correct: (question?.correctAnswer === 0)}">A)
        {{ question?.answer1 }}
      </li>
      <li class="list-group-item" :class="{correct: (question?.correctAnswer === 1)}">B)
        {{ question?.answer2 }}
      </li>
      <li class="list-group-item" :class="{correct: (question?.correctAnswer === 2)}">C)
        {{ question?.answer3 }}
      </li>
    </ul>

    <hr v-if="question !== undefined">

    <div v-if="question !== undefined" class="group-control-container mb-1">
      <b-button variant="outline-secondary" @click="createQuestionGroup">Nieuwe groep</b-button>
    </div>

    <b-accordion>
      <b-accordion-item :visible="questionGroup === this.currentQuestionGroup" :title="'Groep ' + (index+1)"
                        v-for="(questionGroup, index) in questionGroups" :key="questionGroup.id">
        <b-button-group>
          <b-button block variant="outline-secondary" @click="startScanning(questionGroup)"><i
              class="lni lni-search-alt"></i> Scannen
          </b-button>
          <b-button block variant="outline-danger" @click="deleteQuestionGroup(questionGroup)"><i
              class="lni lni-trash-can"></i></b-button>
        </b-button-group>
        <b-table :items="questionGroup.players" :fields="[{key:'name', label:'Naam'}, {key:'actions', label:''}]">
          <template #cell(actions)="row">
            <b-button @click="removePlayerFromGroup(questionGroup, row.item)" variant="outline-danger"><i
                class="lni lni-trash-can"></i></b-button>
          </template>
        </b-table>
      </b-accordion-item>
    </b-accordion>

  </b-container>

  <b-modal v-model="scanView" title="Scannen" hide-footer @hidden="stopScanning">
    <b-container :toast="{root: true}">
      <b-button-group class="mb-1">
        <b-button variant="outline-secondary" @click=rescan><i class="lni lni-reload"></i></b-button>
      </b-button-group>
      <qrcode-stream :torch=this.torch :camera=camera @decode="onDecode">
      </qrcode-stream>
      <b-table :items="this.currentQuestionGroup.players"
               :fields="[{key:'name', label:'Naam'}, {key:'actions', label:''}]">
        <template #cell(actions)="row">
          <b-button @click="removePlayerFromGroup(this.currentQuestionGroup, row.item)" variant="outline-danger"><i
              class="lni lni-trash-can"></i></b-button>
        </template>
      </b-table>
    </b-container>
  </b-modal>


</template>

<script>
import {mapGetters, mapMutations} from "vuex";
import Gateway from "@/service/gateway";
import {QrcodeStream} from 'vue3-qrcode-reader'

export default {
  name: 'QuizmasterView',
  components: {
    QrcodeStream
  },
  async mounted() {
    this.loadQuestion();
    await this.loadQuestionGroups();

  },
  data() {
    return {
      question: {},
      questionGroups: [],
      currentQuestionGroup: {},
      scanView: false,
      torch: false,
      camera: 'off',
      showQuestionState:false
    }
  },
  computed: {
    ...mapGetters({
      signalR: "getSignalR",
      toast: "getToast",
      players: "getPlayers",
      questions: "getQuestions",
      questionIndex: "getCurrentQuestionIndex"
    })
  },
  methods: {
    ...mapMutations({
      nextQuestionIndex: "incrementCurrentQuestion",
      previousQuestionIndex: "decrementCurrentQuestion"
    }),

    async previousQuestion() {
      this.previousQuestionIndex();
      this.loadQuestion();
      await this.loadQuestionGroups();

      this.hideQuestion();
      await this.reloadScoreboard();

      },
    async selectPlayers(){
      this.signalR.invoke("SelectRandomPlayers")
    },

    async reloadScoreboard() {
      this.signalR.invoke("ReloadScoreboard")
    },
    showQuestion() {
      this.signalR.invoke("ShowQuestion", JSON.stringify(this.question))
      this.showQuestionState = true
    },
    hideQuestion() {
      this.signalR.invoke("HideQuestion")
      this.showQuestionState = false;
    },
    async nextQuestion() {
      this.nextQuestionIndex();
      this.loadQuestion();
      await this.loadQuestionGroups();

      this.hideQuestion();
      await this.reloadScoreboard();
    },

    async rescan() {
      this.camera = "off";
      await this.sleep(500);
      this.camera = "auto";
    },
    async sleep(ms) {
      return new Promise(resolve => {
        window.setTimeout(resolve, ms)
      })
    },
    async onDecode(decodedString) {
      if (this.scanView) {
        const player = this.players.find(p => p.code === decodedString);
        const response = await Gateway.Players.postQuestionGroupsPlayer(this.currentQuestionGroup, player);
        if (response.isSuccess) {
          this.toast.show({
            title: 'Gebruiker gescand',
            body: response.data.name,

          }, {
            delay: 1000,
            pos: 'bottom-center',
          });
          this.currentQuestionGroup.players.unshift(response.data)
        } else {
          this.toast.show({
            title: 'Let op!',
            body: response.data,
          }, {
            variant: 'warning',
            delay: 5000,
            pos: 'bottom-center',
          });
        }
      }
    },
    async removePlayerFromGroup(group, player) {
      const response = await Gateway.Players.deleteQuestionGroupsPlayer(group, player);
      if (response.isSuccess) {
        const index = group.players.indexOf(player);
        group.players.splice(index, 1)

      }
    },
    startScanning(questionGroup) {
      this.scanView = true;
      this.currentQuestionGroup = questionGroup
      this.camera = 'auto'
    },
    stopScanning() {
      this.camera = 'off'
    },

    loadQuestion() {
      this.question = this.questions[this.questionIndex]
    },
    async loadQuestionGroups() {
      const result = await Gateway.Questions.getQuestionGroups(this.question);
      if (result.isSuccess) {
        this.questionGroups = result.data;
      }
    },
    async createQuestionGroup() {
      const response = await Gateway.Questions.createQuestionGroups(this.question);
      if (response.isSuccess) {
        this.questionGroups.push(response.data)
        this.startScanning(response.data);
      }
    },
    async deleteQuestionGroup(questionGroup) {
      let data = await Gateway.Questions.deleteQuestionGroups(this.question, questionGroup);
      console.log(data);
      this.questionGroups = this.questionGroups.filter(x => x.id !== questionGroup.id)
    }
  }
}

</script>
<style scoped>
h1 {
  text-align: center
}

.question-navigation-container {
  display: flex;
  justify-content: space-between;
}

.group-control-container {
  display: flex;
  justify-content: flex-end;
}

.list-group-item {
  font-weight: bold;
}

.correct {
  color: green;
}
</style>