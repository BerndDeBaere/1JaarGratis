<template>
  <div class="container">

    <h1 class="text-center text-xl mt-4" v-if='this.isNew && this.question.question == ""'>Nieuwe vraag</h1>
    <h1 class="text-center text-xl mt-4" v-if='this.question.name !== ""'>{{ question.question }}</h1>

    <b-form-group>
      <label for="Name">Vraag</label>
      <b-form-input placeholder="Vraag invullen" v-model=this.question.question></b-form-input>
    </b-form-group>


    <b-form-group>
      <b-input-group>
        <b-input-group-prepend>
          <b-form-radio v-model="question.correctAnswer" value="0"></b-form-radio>
        </b-input-group-prepend>
        <b-form-input v-model="question.answer1" placeholder="Antwoord 1"></b-form-input>
      </b-input-group>
      <b-input-group>
        <b-input-group-prepend>
          <b-form-radio v-model="question.correctAnswer" value="1"></b-form-radio>
        </b-input-group-prepend>
        <b-form-input v-model="question.answer2" placeholder="Antwoord 2"></b-form-input>
      </b-input-group>
      <b-input-group>
        <b-input-group-prepend>
          <b-form-radio v-model="question.correctAnswer" value="2"></b-form-radio>
        </b-input-group-prepend>
        <b-form-input v-model="question.answer3" placeholder="Antwoord 3"></b-form-input>
      </b-input-group>
    </b-form-group>

    <b-button-group class="float-end">
      <b-button variant="outline-danger" @click="cancel"><i class="lni lni-cross-circle"></i> Annuleren</b-button>
      <b-button variant="outline-secondary" @click="saveQuestion"><i class="lni lni-save"></i> Opslaan</b-button>
    </b-button-group>
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
      store.dispatch("postQuestion", this.question);
      router.push({name: 'questions'});
    },
    updateQuestion() {
      store.dispatch("putQuestion", this.question);
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
