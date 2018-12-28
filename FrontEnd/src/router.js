import Vue from "vue";
import VueRouter from "vue-router";
import Home from "./components/Home/Home.vue";

import Apartamentos from "./components/Apartamentos/Listar.vue";
import FormApartamento from "./components/Apartamentos/Form.vue";

import ListarContratos from "./components/Contratos/Listar.vue";
import FormContrato from "./components/Contratos/Form.vue";
import DetalhesDoContrato from "./components/Contratos/Detalhes.vue";

Vue.use(VueRouter);

const routes = [  
    { path: '', component: Home, meta:{title: 'Início'}},  
    
    { path: '/apartamentos', component: Apartamentos, meta:{title: 'Apartamentos'}, name: 'Apartamentos'},      
    { path: '/apartamentos/criar', component: FormApartamento, meta:{title: 'Apartamentos'}, name: 'CriarApartamento'},      
    { path: '/apartamentos/editar/:id', component: FormApartamento, meta:{title: 'Apartamentos'}, name: 'EditarApartamento'},      

    { path: '/contratos', component: ListarContratos, meta:{title: 'Contratos'}, name: 'Contratos'},      
    { path: '/contratos/criar', component: FormContrato, meta:{title: 'Contratos'}, name: 'CriarContrato'},      
    { path: '/contratos/detalhes/:id', component: DetalhesDoContrato, meta:{title: 'Contratos'}, name:'DetalhesDoContrato'},      

    { path: '*', component: Home, meta:{title: 'Início'}},  
];

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes  
});

