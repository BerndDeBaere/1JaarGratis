import { createApp } from 'vue'
import App from './App.vue'
import router from './service/router'
import store from './service/store'

import {BootstrapVue3} from "bootstrap-vue-3";
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue-3/dist/bootstrap-vue-3.css'

import { VueSignalR } from '@dreamonkey/vue-signalr';
import { HubConnectionBuilder } from '@microsoft/signalr';

import {BToastPlugin} from 'bootstrap-vue-3'

const connection = new HubConnectionBuilder()
    .withUrl(process.env.VUE_APP_TITLE + "/signalr")
    .build();

createApp(App)
    .use(store)
    .use(router)
    .use(BootstrapVue3)
    .use(BToastPlugin)
    .use(VueSignalR, {connection})
    .mount('#app')
