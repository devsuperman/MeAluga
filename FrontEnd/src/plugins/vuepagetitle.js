import Vue from 'vue'
import VuePageTitle from "vue-page-title";
import router from "../router";

Vue.use(VuePageTitle,{
    prefix: 'MyApp - ',
    router
  } );
  