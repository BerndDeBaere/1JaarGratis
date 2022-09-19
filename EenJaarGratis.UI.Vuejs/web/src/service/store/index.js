import { createStore } from 'vuex'
import gateway from "@/service/gateway";

export default createStore({
  state() {
    return {
      players : []
    }
  },
  getters: {
  },
  mutations: {
    setPlayers(state, players){
      state.players = players;
    }
  },
  actions: {
    async fetchPlayers({commit}){
      try{
        console.log('start fetching data')
        const data = await gateway.Players.get();
        console.log(data.result);
        commit("setPlayers", data.result);
      }
      catch (error){
        console.error(error)
      }
    },
    async deletePlayer({dispatch}, player){
      try{
        console.log(player)
        await gateway.Players.delete(player);
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
