import { createStore } from 'vuex'
import gateway from "@/service/gateway";

export default createStore({
  state() {
    return {
      players : [],
      questions : [],
      scoreboard: [],
      privacyMode: true}
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
    }
  },
  mutations: {
    setPlayers(state, players){
      state.players = players;
    },
    setQuestions(state, questions){
      state.questions = questions;
    },
    setScoreboard(state, questions){
      state.scoreboard = questions;
    },
    togglePrivacyMode(state){
      state.privacyMode = !state.privacyMode;
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
