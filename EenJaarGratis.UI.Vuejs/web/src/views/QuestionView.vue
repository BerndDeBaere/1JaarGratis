<template>
  <div class="container">

    <h1 class="text-center text-xl mt-4" v-if='this.isNew && this.question.question == ""'>Nieuwe vraag</h1>
    <h1 class="text-center text-xl mt-4" v-if='this.question.name !== ""'>{{ question.question }}</h1>

    <form>
      <div class="form-group">
        <label for="Name">Vraag</label>
        <input type="text" class="form-control" placeholder="Vraag invullen" v-model="this.question.question">
      </div>

      <div class="form-group">

        <div class="input-group">
          <div class="input-group-prepend">
            <div class="input-group-text">
              <input type="radio" v-model="question.correctAnswer" value=0>
            </div>
          </div>
          <input type="text" class="form-control" v-model="this.question.answer1">
        </div>
        <div class="input-group">
          <div class="input-group-prepend">
            <div class="input-group-text">
              <input type="radio" v-model="question.correctAnswer" value=1>
            </div>
          </div>
          <input type="text" class="form-control" v-model="this.question.answer2">
        </div>
        <div class="input-group">
          <div class="input-group-prepend">
            <div class="input-group-text">
              <input type="radio" v-model="question.correctAnswer" value=2>
            </div>
          </div>
          <input type="text" class="form-control" v-model="this.question.answer3">
        </div>
      </div>


      <div class="mb-2 float-right">
        <div class="btn-group" role="group">
          <button type="button" class="btn btn-outline-danger" @click="cancel">
            <i class="lni lni-cross-circle"></i> Annuleren
          </button>
          <button type="button" class="btn btn-outline-secondary" @click="saveQuestion">
            <i class="lni lni-save"></i> Opslaan
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import {useRoute, useRouter} from 'vue-router'
import {mapGetters, useStore} from 'vuex';

let router;
let store;
export default {
  name: 'QuestionView',
  mounted() {
    store = useStore();
    router = useRouter();
    const route = useRoute();
    const id = route.params.id;
    if (id !== undefined) {
      this.question = {...this.questions.find(p => p.id == id)}
    }
    if (this.question.id === undefined) {
      this.isNew = true;
      this.question.question = ""
      this.question.answer1 = ""
      this.question.answer1 = ""
      this.question.answer1 = ""
      this.question.correctAnswer = 0
    }
  },
  computed: {
    ...mapGetters({
      questions: 'getQuestions'
    })
  },
  methods: {
    cancel() {
      router.push({name: 'questions'})
    },
    saveQuestion() {
      if (this.isNew) this.createQuestion();
      else this.updateQuestion();
    },
    createQuestion() {
      store.dispatch("addQuestion", this.question);
      router.push({name: 'questions'});
    },
    updateQuestion() {
      store.dispatch("updateQuestion", this.question);
      router.push({name: 'questions'});
    }
  },
  data() {
    return {
      isNew: false,
      question: {}
    }
  }
}

</script>
