<template>
  <div class="container">
    <h1 class="text-center text-xl mt-4">Vragen</h1>
    <div class="mb-2 float-right">
      <div class="btn-group" role="group" aria-label="Basic example">
        <button class="btn btn-outline-secondary" @click="newQuestion"><i class="lni lni-circle-plus"></i></button>
        <button class="btn btn-outline-secondary" type="button" data-toggle="collapse" data-target=".multi-collapse" aria-expanded="false" v-if="privacyMode"><i class="lni lni-eye"></i> toon/verberg antwoorden</button>
<!--        <button class="btn" :class="{'btn-outline-secondary':(!privacyMode), 'btn-secondary':(privacyMode)}" type="button" @click="togglePrivacy">-->
<!--                 Privacy-->
<!--        </button>-->

        <button type="button" class="btn btn-outline-secondary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          Extra opties
        </button>
        <div class="dropdown-menu">
          <button type="button" class="dropdown-item btn" :class="{'active':(privacyMode)}" @click="togglePrivacy"><i class="lni lni-eye"></i> Privacy mode</button>
          <button type="button" class="dropdown-item btn" @click="uploadExcel">Upload excel</button>
        </div>

      </div>
    </div>
    <br>

    <table class="table">
      <thead>
      <tr>
        <th scope="col">Vraag</th>
        <th scope="col">Antwoorden</th>
        <th class="col-2" scope="col">Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for='question in questions' :key="question.id">
        <td>{{ question.question }}</td>
        <td>
          <div :class="{show:(!this.privacyMode)}" class="collapse multi-collapse">
            <ul class="list-group">
              <li class="list-group-item" :class="{correct: (question.correctAnswer == 0)}">{{ question.answer1 }}</li>
              <li class="list-group-item" :class="{correct: (question.correctAnswer == 1)}">{{ question.answer2 }}</li>
              <li class="list-group-item" :class="{correct: (question.correctAnswer == 2)}">{{ question.answer3 }}</li>
            </ul>
          </div>
        </td>
        <td>
          <div class="btn-group" role="group" aria-label="Basic example">
            <button class="btn btn-outline-secondary btn-sm" @click="editQuestion(question)"><i
                class="lni lni-pencil"></i> Bewerken
            </button>
            <button class="btn btn-outline-danger btn-sm" @click="deleteQuestion(question)"><i
                class="lni lni-trash-can"></i></button>
          </div>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
.list-group {
  font-weight: bold;
  color: red;
}

.correct {
  color: green;
}
</style>

<script>
import {mapGetters, useStore} from "vuex";
import {useRouter} from "vue-router";

let store;
let router;
export default {
  name: 'QuestionsView',
  setup() {
    store = useStore();
    router = useRouter();
  },
  computed: {
    ...mapGetters({
      questions: 'getQuestions',
      privacyMode: 'getPrivacyMode'
    })
  },
  methods: {
    uploadExcel(){
      router.push({name: 'importQuestions'})
    },
    togglePrivacy(){
      store.commit("togglePrivacyMode");
    },
    newQuestion() {
      router.push({name: 'newQuestion'})
    },
    deleteQuestion(player) {
      store.dispatch("deleteQuestion", player)
    },
    editQuestion(player) {
      router.push({name: 'editQuestion', params: {id: player.id}})
    }
  }
}

</script>
