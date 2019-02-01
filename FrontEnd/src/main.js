import '@babel/polyfill';
import './plugins/vuepagetitle';
import "materialize-css/dist/css/materialize.min.css";
import "materialize-css/dist/js/materialize.min.js";
import './registerServiceWorker'
import Vue from 'vue';
import App from './App.vue';
import router from "./router";
import VueResource from "vue-resource";

Vue.config.productionTip = false;
Vue.use(VueResource);
Vue.http.options.root = 'http://localhost:49459/api/';

new Vue({
  render: h => h(App),  
  router  
}).$mount('#app');