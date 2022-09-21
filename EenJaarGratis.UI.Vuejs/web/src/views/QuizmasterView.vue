<template>
  <div class="container">
    <div class="question-navigation-container mt-1">
      <button class="btn btn-outline-secondary" @click="previousQuestion">Vorige</button>
      <button class="btn btn-outline-secondary" @click="nextQuestion">Volgende</button>
    </div>
    <h1>{{currentQuestion.order+1}}) {{currentQuestion.question}}</h1>
    <ul class="list-group">
      <li class="list-group-item" :class="{correct: (currentQuestion.correctAnswer === 0)}">A) {{ currentQuestion.answer1 }}</li>
      <li class="list-group-item" :class="{correct: (currentQuestion.correctAnswer === 1)}">B) {{ currentQuestion.answer2 }}</li>
      <li class="list-group-item" :class="{correct: (currentQuestion.correctAnswer === 2)}">C) {{ currentQuestion.answer3 }}</li>
    </ul>

    <hr>

    <div class="group-control-container mb-1">
      <button class="btn btn-outline-secondary" @click="createQuestionGroup">Nieuwe groep</button>
    </div>

    <div id="accordion">
      <div class="card mb-1" v-for="(questionGroup, index) in questionGroups" :key="questionGroup.id">
        <div class="card-header">
          <h5 class="mb-0 question-navigation-container">
            <button class="btn btn-light" data-toggle="collapse" v-bind:data-target="'#collapse'+questionGroup.id">
              Groep {{index+1}}
            </button>

            <button class="btn btn-outline-secondary" @click="startScanning(questionGroup)">
              Qr codes scannen
            </button>
            <button class="btn btn-outline-danger" @click="deleteQuestionGroup(questionGroup)">
              Verwijderen
            </button>
          </h5>
        </div>
        <div v-bind:id="'collapse'+questionGroup.id" class="collapse" data-parent="#accordion">
          <div class="card-body">
            <ul>
              <li v-for="player in questionGroup.players" :key=player.id>{{player.name}}</li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {mapGetters, mapMutations} from "vuex";
import Gateway from "@/service/gateway";

export default {
  name: 'QuizmasterView',
  computed:{
    ...mapGetters({
      currentQuestion: "getCurrentQuestion"
    })
  },
  data(){
    return {
      questionGroups:[]
    }
  },
  methods:{
    startScanning(questionGroup){
      alert(questionGroup.id);
    },
    async loadQuestionGroups(){
      let data = await Gateway.Questions.getQuestionGroups(this.currentQuestion);
      this.questionGroups = data.result;
    },
    async createQuestionGroup(){
      let data = await Gateway.Questions.createQuestionGroups(this.currentQuestion);
      console.log(data);
      this.questionGroups.push(data)
    },
    async deleteQuestionGroup(questionGroup){
      if(confirm("Wil je deze groep zeker verwijderen?"))
      {
        let data = await Gateway.Questions.deleteQuestionGroups(this.currentQuestion, questionGroup);
        console.log(data);
        this.questionGroups = this.questionGroups.filter(x => x.id !== questionGroup.id)
      }
    },
    async nextQuestion(){
      this.nextQuestionAction();
      await this.loadQuestionGroups();
    },
    async previousQuestion(){
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
h1{
  text-align:center
}
.question-navigation-container{
  display: flex;
  justify-content: space-between;
}
.group-control-container{
  display: flex;
  justify-content: flex-end;
}
.list-group {
  font-weight: bold;
  color: red;
}
.correct {
  color: green;
}
</style>