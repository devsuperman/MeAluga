<template>
     <form @submit.prevent="Salvar()">
      
      <div class="input-field">
        <input id='dataDeInicio' type='date' class="validate" required v-model='contrato.DataDeInicio'>
        <label for="dataDeInicio" class='active'>Data de Início</label>      
      </div>        
      
      <router-link :to="{name: 'Contratos'}">
        <a class="btn-floating btn-large waves-effect waves-light red left">
          <i class="material-icons">arrow_back</i>
        </a >
      </router-link>      

      <button class="btn-floating btn-large waves-effect waves-light red right">
        <i class="material-icons">check</i>
      </button>

    </form>          
</template>

<script>
import CriarContrato from "../../domain/contrato/CriarContrato";
import ContratoService from "../../domain/contrato/ContratoService";
import ApartamentoService from "../../domain/apartamento/ApartamentoService";

  export default {
    data () {
      return {   
        contrato: new CriarContrato(),                
        apartamentosDesocupados: [],        
        estadoscivis: ['Solteiro (a)','Casado (a)']
        }
    },

    created(){
      this.contratoService = new ContratoService(this.$resource);      
      this.ApartamentoService = new ApartamentoService(this.$resource);            
      this.ApartamentoService.listarDesocupados().then(x => this.apartamentosDesocupados = x);                
      
    },       
    methods:{
      Salvar(){                 
        this.contratoService.salvar(this.contrato)
          .then(resposta => {                  
            var url = {name: 'DetalhesDoContrato', params: {id: resposta.body.id}};                
            this.$router.push(url);                                    
        });        
      }      
    }
  }

</script>

<style scoped>

</style>


