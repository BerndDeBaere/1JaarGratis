import { createStore } from 'vuex'
import gateway from "@/service/gateway";

export default createStore({
  state() {
    return {
      players : [],
      questions : [],
      scoreboard: [],
      currentQuestion: {},
      privacyMode: true,
    }
  },
  getters: {
    getPlayers(state){
      return state.players
    },
    getQuestions(state){
      return state.questions
    },
    getPrivacyMode(state){
      return state.privacyMode
    },
    getScoreboard(state){
      return state.scoreboard.sort((a, b) => b.points - a.points)
    },
    getCurrentQuestion(state){
      return state.currentQuestion;
    }
  },
  mutations: {
    setPlayers(state, players){
      state.players = players;
    },
    setQuestions(state, questions){
      state.questions = questions;
      state.currentQuestion = questions[0]
    },
    setScoreboard(state, questions){
      state.scoreboard = questions;
    },
    setCurrentQuestion(state, currentQuestion){
      state.currentQuestion = currentQuestion;
    },
    togglePrivacyMode(state){
      state.privacyMode = !state.privacyMode;
    },
    incrementCurrentQuestion(state){
      let max = Math.max.apply(null, state.questions.map(q => q.order));
      let index = Math.min(state.currentQuestion.order + 1, max);
      state.currentQuestion = state.questions.find(q => q.order === index);
    },
    decrementCurrentQuestion(state){
      let index = Math.max(state.currentQuestion.order - 1, 0);
      state.currentQuestion = state.questions.find(q => q.order === index);
    }
  },

  actions: {
    async fetchQuestions({commit}){
      try{
        const data = await gateway.Questions.get();
        commit("setQuestions", data.result);
      }
      catch (error){
        console.error(error)
      }
    },
    async fetchScoreboard({commit}){
      try{
        const data = await gateway.Players.getScoreboard();
        commit("setScoreboard", data.result);
      }
      catch (error){
        console.error(error)
      }
    },
    async deleteQuestion({dispatch}, question){
      try{
        await gateway.Questions.delete(question);
        await dispatch('fetchQuestions')
      }
      catch (error){
        console.error(error)
      }
    },
    async addQuestion({dispatch}, question){
      try{
        await gateway.Questions.post(question);
        await dispatch('fetchQuestions')
      }
      catch (error){
        console.error(error)
      }
    },
    async updateQuestion({dispatch}, question){
      try{
        await gateway.Questions.put(question);
        await dispatch('fetchQuestions')
      }
      catch (error){
        console.error(error)
      }
    },


    async fetchPlayers({commit}){
      try{
        const data = await gateway.Players.get();
        commit("setPlayers", data.result);
      }
      catch (error){
        console.error(error)
      }
    },
    async deletePlayer({dispatch}, player){
      try{
        await gateway.Players.delete(player);
        await dispatch('fetchPlayers')
      }
      catch (error){
        console.error(error)
      }
    },
    async addPlayer({dispatch}, player){
      try{
        await gateway.Players.post(player);
        await dispatch('fetchPlayers')
      }
      catch (error){
        console.error(error)
      }
    },
    async updatePlayer({dispatch}, player){
      try{
        await gateway.Players.put(player);
        await dispatch('fetchPlayers')
      }
      catch (error){
        console.error(error)
      }
    }
  },
  modules: {
  }
})
