import { createRouter, createWebHistory } from 'vue-router'
import PlayersView from "@/views/PlayersView";
import ScoreboardView from "@/views/ScoreboardView";
import HomeView from "@/views/HomeView";
import QuestionsView from "@/views/QuestionsView";
import PlayerView from "@/views/PlayerView";
import QuestionView from "@/views/QuestionView";
import ImportQuestionsView from "@/views/ImportQuestionsView";
import QuizmasterView from "@/views/QuizmasterView";



const routes = [
  {
    path: '/Spelers',
    name: 'players',
    component: PlayersView
  }, {
    path: '/Speler/:id',
    name: 'editPlayer',
    component: PlayerView
  }, {
    path: '/Speler',
    name: 'newPlayer',
    component: PlayerView
  }, {
    path: '/Vraag/:id',
    name: 'editQuestion',
    component: QuestionView
  }, {
    path: '/Vraag',
    name: 'newQuestion',
    component: QuestionView
  }, {
    path: '/Vragen/Importeren',
    name: 'importQuestions',
    component: ImportQuestionsView
  }, {
    path: '/Quiz',
    name: 'quizmaster',
    component: QuizmasterView
  }, {
    path: '/',
    name: 'home',
    component: HomeView
  }, {
    path: '/Scorebord',
    name: 'scoreboard',
    component: ScoreboardView
  }, {
    path: '/Vragen',
    name: 'questions',
    component: QuestionsView
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
