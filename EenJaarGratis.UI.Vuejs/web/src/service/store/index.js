import {createStore} from 'vuex'
import gateway from "@/service/gateway";

export default createStore({
    state() {
        return {
            signalR: {},
            players: [],
            questions: [],
            currentQuestion: {},
        }
    },
    getters: {
        getPlayers(state) {
            return state.players
        },
        getQuestions(state) {
            return state.questions
        },
        getCurrentQuestion(state) {
            return state.currentQuestion;
        },
        getSignalR(state){
            return state.signalR;
        }
    },
    mutations: {
        //QUESTIONS
        setQuestions(state, questions) {
            state.questions = questions;
            state.currentQuestion = questions[0]
        }, addQuestion(state, question) {
            state.questions.push(question)
        }, updateQuestion(state, question) {
            state.questions = state.questions.map(q => q.id === question.id ? question : q);
        }, removeQuestion(state, question) {
            const index = state.questions.indexOf(question);
            if (index >= 0) {
                state.questions.splice(index, 1)
            }
        },

        //PLAYERS
        setPlayers(state, players) {
            state.players = players;
        }, addPlayer(state, player) {
            state.players.push(player)
        }, updatePlayer(state, player) {
            state.players = state.players.map(q => q.id === player.id ? player : q);
        }, removePlayer(state, player) {
            const index = state.players.indexOf(player);
            console.log(player)
            console.log("index " + index)
            if (index >= 0) {
                state.players.splice(index, 1)
            }
        },

        setSignalR(state, signalR){
            state.signalR = signalR;
        },


        //QUIZMASTER
        incrementCurrentQuestion(state) {
            let max = Math.max.apply(null, state.questions.map(q => q.order));
            let index = Math.min(state.currentQuestion.order + 1, max);
            state.currentQuestion = state.questions.find(q => q.order === index);
        },
        decrementCurrentQuestion(state) {
            let index = Math.max(state.currentQuestion.order - 1, 0);
            state.currentQuestion = state.questions.find(q => q.order === index);
        }
    },
    actions: {
        //QUESTIONS
        async getQuestions({commit}) {
            const response = await gateway.Questions.get();
            if (response.isSuccess) {
                commit("setQuestions", response.data);
            }
        }, async postQuestion({commit}, question) {
            const response = await gateway.Questions.post(question);
            if (response.isSuccess) {
                await commit('addQuestion', response.data)
            }
        }, async putQuestion({commit}, question) {
            const response = await gateway.Questions.put(question);
            if (response.isSuccess) {
                commit("updateQuestion", question)
            }
        }, async deleteQuestion({commit}, question) {
            const response = await gateway.Questions.delete(question);
            if (response.isSuccess) {
                commit("removeQuestion", question)
            }
        },

        //PLAYERS
        async getPlayers({commit}) {
            const response = await gateway.Players.get();
            if (response.isSuccess) {
                commit("setPlayers", response.data);
            }
        }, async postPlayer({commit}, player) {
            const response = await gateway.Players.post(player);
            if (response.isSuccess) {
                commit("addPlayer", response.data);
            }
        }, async putPlayer({commit}, player) {
            const response = await gateway.Players.put(player);
            if (response.isSuccess) {
                commit("updatePlayer", response.data);
            }
        }, async deletePlayer({commit}, player) {
            const response = await gateway.Players.delete(player);
            if (response.isSuccess) {
                commit("removePlayer", player);
            }
        }
    },
    modules: {}
})
