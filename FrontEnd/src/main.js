import '@babel/polyfill'
import './plugins/vuetify'
import Vue from 'vue';
import App from './App.vue';
import VueResource from "vue-resource";
import router from "./router";
import VeeValidate from "vee-validate";

Vue.config.productionTip = false;

Vue.use(VeeValidate);
Vue.use(VueResource);

new Vue({
  render: h => h(App),  
  router,
  http:{
    root: 'https://localhost:5001/api/'
  }
}).$mount('#app');