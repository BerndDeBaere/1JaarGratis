<template>
  <div class="container">
    <div class="question-navigation-container mt-1">
      <b-button @click="previousQuestion" variant="outline-secondary">Vorige</b-button>
      <b-button @click="nextQuestion" variant="outline-secondary">Volgende</b-button>
    </div>
    <h1>{{ currentQuestion.order + 1 }}) {{ currentQuestion.question }}</h1>
    <ul class="list-group">
      <li class="list-group-item" :class="{correct: (currentQuestion.correctAnswer === 0)}">A)
        {{ currentQuestion.answer1 }}
      </li>
      <li class="list-group-item" :class="{correct: (currentQuestion.correctAnswer === 1)}">B)
        {{ currentQuestion.answer2 }}
      </li>
      <li class="list-group-item" :class="{correct: (currentQuestion.correctAnswer === 2)}">C)
        {{ currentQuestion.answer3 }}
      </li>
    </ul>

    <hr>

    <div class="group-control-container mb-1">
      <b-button variant="outline-secondary" @click="createQuestionGroup">Nieuwe groep</b-button>
    </div>


    <div class="accordion" role="tablist">
      <b-card no-body v-for="(questionGroup, index) in questionGroups" :key="questionGroup.id">
        <b-card-header header-tag="header" class="p-1" role="tab">
          <div class="question-navigation-container">
          <b-button block v-b-toggle="'accordion-'+index" variant="light">Groep {{index+1}}</b-button>
          <b-button-group>
            <b-button block variant="outline-secondary" @click="startScanning(questionGroup)"><i class="lni lni-search-alt"></i> Scannen</b-button>
            <b-button block variant="outline-danger" @click="deleteQuestionGroup(questionGroup)"><i class="lni lni-trash-can"></i></b-button>
          </b-button-group>
          </div>
        </b-card-header>
        <b-collapse :id="'accordion-'+index" accordion="my-accordion" role="tabpanel">
          <b-card-body>
            <ul>
              <li v-for="player in questionGroup.players" :key=player.id>{{player.name}}</li>
            </ul>
          </b-card-body>
        </b-collapse>
      </b-card>
    </div>
  </div>


  <b-modal v-model="scanView" title="Scannen" hide-footer @hidden="stopScanning">
    <qrcode-stream @decode="onDecode"></qrcode-stream>
  </b-modal>


</template>

<script>
import {mapGetters, mapMutations} from "vuex";
import Gateway from "@/service/gateway";
import { QrcodeStream } from 'vue3-qrcode-reader'

export default {
  name: 'QuizmasterView',
  components:{
    QrcodeStream
  },
  computed: {
    ...mapGetters({
      players: "getPlayers",
      currentQuestion: "getCurrentQuestion",
    })
  },
  data() {
    return {
      questionGroups: [],
      currentQuestionGroup:{},
      scanView: false
    }
  },
  methods: {
    async onDecode(decodedString) {
      if(this.scanView){
        let player = this.players.find(p => p.code === decodedString);
        let data = await Gateway.Players.postQuestionGroupsPlayer(this.currentQuestionGroup,player);
        this.currentQuestionGroup.players.push(data)
      }
      },
    startScanning(questionGroup) {
      this.scanView = true;
      this.currentQuestionGroup = questionGroup
    },
    stopScanning(){
      console.log("close")
      this.currentQuestionGroup = null
    },
    async loadQuestionGroups() {
      let data = await Gateway.Questions.getQuestionGroups(this.currentQuestion);
      this.questionGroups = data.result;
    },
    async createQuestionGroup() {
      let data = await Gateway.Questions.createQuestionGroups(this.currentQuestion);
      console.log(data);
      this.questionGroups.push(data)
    },
    async deleteQuestionGroup(questionGroup) {
      let data = await Gateway.Questions.deleteQuestionGroups(this.currentQuestion, questionGroup);
      console.log(data);
      this.questionGroups = this.questionGroups.filter(x => x.id !== questionGroup.id)
    },
    async nextQuestion() {
      this.nextQuestionAction();
      await this.loadQuestionGroups();
    },
    async previousQuestion() {
      this.previousQuestionAction()
      await this.loadQuestionGroups();
    },
    ...mapMutations({
      nextQuestionAction: "incrementCurrentQuestion",
      previousQuestionAction: "decrementCurrentQuestion"
    })
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