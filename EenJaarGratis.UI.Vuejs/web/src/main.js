import { createApp } from 'vue'
import App from './App.vue'
import router from './service/router'
import store from './service/store'
import naive from "naive-ui"

createApp(App).use(naive).use(store).use(router).mount('#app')
