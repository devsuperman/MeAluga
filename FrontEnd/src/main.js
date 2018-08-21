import '@babel/polyfill';
import './plugins/vuetify';
import './plugins/veevalidate';
import './plugins/vuepagetitle';
import Vue from 'vue';
import App from './App.vue';
import router from "./router";
import VueResource from "vue-resource";

Vue.config.productionTip = false;
Vue.use(VueResource);
// Vue.http.options.root = 'https://localhost:5001/api/';
Vue.http.options.root = 'http://localhost:49459/api/';

new Vue({
  render: h => h(App),  
  router  
}).$mount('#app');