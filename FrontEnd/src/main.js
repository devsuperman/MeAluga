import Vue from 'vue';
import App from './App.vue';
import VueResource from "vue-resource";
import VueRouter from "vue-router";
import { routes } from "./routes";
import VeeValidate from "vee-validate";

Vue.config.productionTip = false;

Vue.use(VeeValidate);
Vue.use(VueRouter);
Vue.use(VueResource);

const router = new VueRouter({
  routes,
  mode: 'history'
});

new Vue({
  render: h => h(App),
  http:{
    root: 'https://localhost:5001/api/'
  },
  router
}).$mount('#app');




// Vue.http.options.root = 'https://localhost:5001/api/';