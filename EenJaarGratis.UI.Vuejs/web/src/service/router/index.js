import { createRouter, createWebHistory } from 'vue-router'
import PlayersView from "@/views/PlayersView";
import ScoreboardView from "@/views/ScoreboardView";
import HomeView from "@/views/HomeView";
import QuestionsView from "@/views/QuestionsView";



const routes = [
  {
    path: '/Spelers',
    name: 'players',
    component: PlayersView
  },
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/Scorebord',
    name: 'scoreboard',
    component: ScoreboardView
  },
  {
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
