import Vue from "vue";
import VueRouter from "vue-router";
import Home from "./components/Home/Home.vue";

import ListarImoveis from "./components/Imoveis/Listar.vue";
import CriarImovel from "./components/Imoveis/Criar.vue";
import DetalhesDoImovel from "./components/Imoveis/Detalhes.vue";
import EditarImovel from "./components/Imoveis/Editar.vue";

import ListarLocatarios from "./components/Locatarios/Listar.vue";
import CriarLocatario from "./components/Locatarios/Criar.vue";
import DetalhesDoLocatario from "./components/Locatarios/Detalhes.vue";
import EditarLocatario from "./components/Locatarios/Editar.vue";

import ListarContratos from "./components/Contratos/Listar.vue";

Vue.use(VueRouter);

const routes = [  
    { path: '', component: Home, meta:{title: 'Início'}},  
    
    { path: '/imoveis', component: ListarImoveis, meta:{title: 'Imóveis'}, name: 'Imoveis'},      
    { path: '/imoveis/criar', component: CriarImovel, meta:{title: 'Novo Imóvel'}, name: 'CriarImovel'},      
    { path: '/imoveis/detalhes/:id', component: DetalhesDoImovel, meta:{title: 'Imóvel'}, name:'DetalhesDoImovel'},      
    { path: '/imoveis/editar/:id', component: EditarImovel, meta:{title: 'Imóvel'}, name: 'EditarImovel'},      


    { path: '/locatarios', component: ListarLocatarios, meta:{title: 'Locatários'}, name: 'Locatarios'},      
    { path: '/locatarios/criar', component: CriarLocatario, meta:{title: 'Locatário'}, name: 'CriarLocatario'},      
    { path: '/locatarios/detalhes/:id', component: DetalhesDoLocatario, meta:{title: 'Locatários'}, name:'DetalhesDoLocatario'},      
    { path: '/locatarios/editar/:id', component: EditarLocatario, meta:{title: 'Locatários'}, name: 'EditarLocatario'},      

    { path: '/contratos', component: ListarContratos, meta:{title: 'Contratos'}, name: 'Contratos'},      

    { path: '*', component: Home, meta:{title: 'Início'}},  
];

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes  
});

