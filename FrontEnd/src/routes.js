import Home from "./components/Home/Home.vue";
import Imoveis from "./components/Imoveis/Imoveis.vue";

export const routes = [
  { path: '/', component: Home},  
  { path: '/imoveis', component: Imoveis},
]