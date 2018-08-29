import Vue from "vue";
import VueRouter from "vue-router";
import Home from "./components/Home/Home.vue";

import ListarImoveis from "./components/Imoveis/Listar.vue";
import DetalhesDoImovel from "./components/Imoveis/Detalhes.vue";
import FormImovel from "./components/Imoveis/Form.vue";

import ListarLocatarios from "./components/Locatarios/Listar.vue";
import DetalhesDoLocatario from "./components/Locatarios/Detalhes.vue";
import FormLocatario from "./components/Locatarios/Form.vue";

import ListarContratos from "./components/Contratos/Listar.vue";
import FormContrato from "./components/Contratos/Form.vue";

Vue.use(VueRouter);

const routes = [  
    { path: '', component: Home, meta:{title: 'Início'}},  
    
    { path: '/imoveis', component: ListarImoveis, meta:{title: 'Imóveis'}, name: 'Imoveis'},      
    { path: '/imoveis/detalhes/:id', component: DetalhesDoImovel, meta:{title: 'Imóvel'}, name:'DetalhesDoImovel'},      
    { path: '/imoveis/criar', component: FormImovel, meta:{title: 'Imóvel'}, name: 'CriarImovel'},      
    { path: '/imoveis/editar/:id', component: FormImovel, meta:{title: 'Imóvel'}, name: 'EditarImovel'},      


    { path: '/locatarios', component: ListarLocatarios, meta:{title: 'Locatários'}, name: 'Locatarios'},          
    { path: '/locatarios/detalhes/:id', component: DetalhesDoLocatario, meta:{title: 'Locatários'}, name:'DetalhesDoLocatario'},      
    { path: '/locatarios/criar', component: FormLocatario, meta:{title: 'Locatários'}, name: 'CriarLocatario'},      
    { path: '/locatarios/editar/:id', component: FormLocatario, meta:{title: 'Locatários'}, name: 'EditarLocatario'},      

    { path: '/contratos', component: ListarContratos, meta:{title: 'Contratos'}, name: 'Contratos'},      
    { path: '/contratos/criar', component: FormContrato, meta:{title: 'Contratos'}, name: 'CriarContrato'},      

    { path: '*', component: Home, meta:{title: 'Início'}},  
];

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes  
});

