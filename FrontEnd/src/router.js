import Vue from "vue";
import VueRouter from "vue-router";

import Home from "./components/Home/Home.vue";
import Imoveis from "./components/Imoveis/Imoveis.vue";
import Locatarios from "./components/Locatarios/Locatarios.vue";

Vue.use(VueRouter);

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    { path: '', component: Home},  
    { path: '/imoveis', component: Imoveis},      
    { path: '/locatarios', component: Locatarios}
  ]
});

