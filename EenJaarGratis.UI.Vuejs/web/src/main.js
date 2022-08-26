import { createApp } from 'vue'
import App from './App.vue'
import router from './service/router'
import store from './service/store'

createApp(App).use(store).use(router).mount('#app')
