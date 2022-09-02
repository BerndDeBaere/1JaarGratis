import { createRouter, createWebHistory } from 'vue-router'
import PlayersView from "@/views/PlayersView";
import AboutView from "@/views/AboutView";


const routes = [
  {
    path: '/',
    name: 'players',
    component: PlayersView
  },
  {
    path: '/about',
    name: 'about',
    component: AboutView
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
