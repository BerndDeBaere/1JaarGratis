import {createStore} from 'vuex'
import gateway from "@/service/gateway";

export default createStore({
    state() {
        return {
            signalR: {},
            toast:{},
            players: [],
            questions: [],
            currentQuestionIndex: 0,
        }
    },
    getters: {
        getPlayers(state) {
            return state.players
        },
        getQuestions(state) {
            return state.questions
        },
        getCurrentQuestionIndex(state) {
            return state.currentQuestionIndex;
        },
        getSignalR(state) {
            return state.signalR;
        },
        getToast(state) {
            return state.toast;
        }
    },
    mutations: {
        //QUESTIONS
        setQuestions(state, questions) {
            state.questions = questions;
            state.currentQuestionIndex = 0
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

        setSignalR(state, signalR) {
            state.signalR = signalR;
        },
        setToast(state, toast) {
            state.toast = toast;
        },


        //QUIZMASTER
        incrementCurrentQuestion(state) {
            let max = Math.max.apply(null, state.questions.map(q => q.order));
            state.currentQuestionIndex = Math.min(state.currentQuestionIndex + 1, max);
        },
        decrementCurrentQuestion(state) {
            state.currentQuestionIndex = Math.max(state.currentQuestionIndex - 1, 0);
        }
    },
    actions: {
        //QUESTIONS
        async getQuestions({commit}) {
            const response = await gateway.Questions.get();
            if (response.isSuccess) {
                commit("setQuestions", response.data);
            }
            return response;
        }, async postQuestion({commit}, question) {
            const response = await gateway.Questions.post(question);
            if (response.isSuccess) {
                await commit('addQuestion', response.data)
            }
            return response;
        }, async putQuestion({commit}, question) {
            const response = await gateway.Questions.put(question);
            if (response.isSuccess) {
                commit("updateQuestion", question)
            }
            return response;
        }, async deleteQuestion({commit}, question) {
            const response = await gateway.Questions.delete(question);
            if (response.isSuccess) {
                commit("removeQuestion", question)
            }
            return response;
        },

        //PLAYERS
        async getPlayers({commit}) {
            const response = await gateway.Players.get();
            if (response.isSuccess) {
                commit("setPlayers", response.data);
            }
            return response;
        }, async postPlayer({state, commit}, player) {
            const response = await gateway.Players.post(player);
            if (response.isSuccess) {
                commit("addPlayer", response.data);
                state.signalR.invoke("ReloadPlayers")
            }
            return response;
        }, async putPlayer({state, commit}, player) {
            const response = await gateway.Players.put(player);
            if (response.isSuccess) {
                commit("updatePlayer", response.data);
                state.signalR.invoke("ReloadPlayers")

            }
            return response;
        }, async deletePlayer({state, commit}, player) {
            const response = await gateway.Players.delete(player);
            if (response.isSuccess) {
                commit("removePlayer", player);
                state.signalR.invoke("ReloadPlayers")
            }
            return response;
        }
    },
    modules: {}
})
