import Vue from "vue";
import VueRouter from "vue-router";
import Home from "./components/Home/Home.vue";

import Imoveis from "./components/Imoveis/Imoveis.vue";
import ImoveisNew from "./components/Imoveis/ImoveisNew.vue";
import ImoveisDetails from "./components/Imoveis/ImoveisDetails.vue";
import ImoveisEdit from "./components/Imoveis/ImoveisEdit.vue";

import Locatarios from "./components/Locatarios/Locatarios.vue";
import LocatariosNew from "./components/Locatarios/LocatariosNew.vue";
import LocatariosDetails from "./components/Locatarios/LocatariosDetails.vue";
import LocatariosEdit from "./components/Locatarios/LocatariosEdit.vue";

import Contratos from "./components/Contratos/Contratos.vue";

Vue.use(VueRouter);

const routes = [  
    { path: '', component: Home, meta:{title: 'Início'}},  
    
    { path: '/imoveis', component: Imoveis, meta:{title: 'Imóveis'}, name: 'Imoveis'},      
    { path: '/imoveis/new', component: ImoveisNew, meta:{title: 'Novo Imóvel'}, name: 'CriarImovel'},      
    { path: '/imoveis/details/:id', component: ImoveisDetails, meta:{title: 'Imóvel'}, name:'DetalhesDoImovel'},      
    { path: '/imoveis/edit/:id', component: ImoveisEdit, meta:{title: 'Imóvel'}, name: 'EditarImovel'},      


    { path: '/locatarios', component: Locatarios, meta:{title: 'Locatários'}, name: 'Locatarios'},      
    { path: '/locatarios/new', component: LocatariosNew, meta:{title: 'Locatário'}, name: 'CriarLocatario'},      
    { path: '/locatarios/details/:id', component: LocatariosDetails, meta:{title: 'Locatários'}, name:'DetalhesDoLocatario'},      
    { path: '/locatarios/edit/:id', component: LocatariosEdit, meta:{title: 'Locatários'}, name: 'EditarLocatario'},      

    { path: '/contratos', component: Contratos, meta:{title: 'Contratos'}, name: 'Contratos'},      

    { path: '*', component: Home, meta:{title: 'Início'}},  
];

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes  
});

