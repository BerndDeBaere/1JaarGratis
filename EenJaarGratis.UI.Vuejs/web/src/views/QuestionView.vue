<template>
  <div class="container">

    <h1 class="text-center text-xl mt-4" v-if='this.isNew && this.question.question === ""'>Nieuwe vraag</h1>
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
import {mapActions, mapGetters} from 'vuex';

let router;
export default {
  name: 'QuestionView',
  mounted() {
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
    ...mapActions({
      postQuestion:"postQuestion",
      putQuestion: "putQuestion"
    }),
    cancel() {
      router.push({name: 'questions'})
    },
    async saveQuestion() {
      if (this.isNew) await this.createQuestion();
      else await this.updateQuestion();
    },
    async createQuestion() {
      const response = await this.postQuestion(this.question);
      if(response.isSuccess){
        router.push({name: 'questions'});
      }    },
    async updateQuestion() {
      const response = await this.putQuestion(this.question);
      if(response.isSuccess){
      router.push({name: 'questions'});
      }
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
