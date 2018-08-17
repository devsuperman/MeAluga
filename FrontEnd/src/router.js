import Vue from "vue";
import VueRouter from "vue-router";
import Home from "./components/Home/Home.vue";
import Imoveis from "./components/Imoveis/Imoveis.vue";
import ImoveisNew from "./components/Imoveis/ImoveisNew.vue";
import ImoveisDetails from "./components/Imoveis/ImoveisDetails.vue";
import ImoveisEdit from "./components/Imoveis/ImoveisEdit.vue";
import Locatarios from "./components/Locatarios/Locatarios.vue";

Vue.use(VueRouter);

const routes = [  
    { path: '', component: Home, meta:{title: 'Início'}},  
    { path: '/imoveis', component: Imoveis, meta:{title: 'Imóveis'}, name: 'Imoveis'},      
    { path: '/imoveis/new', component: ImoveisNew, meta:{title: 'Novo Imóvel'}},      
    { path: '/imoveis/details/:id', component: ImoveisDetails, meta:{title: 'Imóvel'}, name:'DetalhesDoImovel'},      
    { path: '/imoveis/edit/:id', component: ImoveisEdit, meta:{title: 'Imóvel'}, name: 'EditarImovel'},      
    { path: '/locatarios', component: Locatarios, meta:{title: 'Locatários'}},
    { path: '*', component: Home, meta:{title: 'Início'}},  
];

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes  
});

