<template>
     <form @submit.prevent="Salvar()">
      
      <div class="input-field">
        <input id='dataDeInicio' type='date' class="validate" required v-model='contrato.DataDeInicio'>
        <label for="dataDeInicio" class='active'>Data de Início</label>      
      </div>     

      <p>
        <label>
          <input type="radio" value='6' checked v-model='contrato.duracao'/>
          <span>06 Meses</span>
        </label>
      </p>
      <p>
        <label>
          <input type="radio" value='12' v-model='contrato.duracao'/>
          <span>01 ano</span>
        </label>
      </p>

      <div class="input-field">
        <input id='valor' type='number' class="validate" required v-model='contrato.Valor'>
        <label for="valor" class='active'>Valor</label>      
      </div>  

      <div class="input-field">
        <select v-model="contrato.Apartamento">
          <option value=''> Selecione </option>
          <option v-for="ap in apartamentosDesocupados" :key="ap.id" :value='ap.id'> {{ ap.apelido }}</option>                              
        </select>
        <label>Materialize Select</label>
      </div>

      <div>
        <p>
          😎
          Locatário
        </p>
      </div>
      
      
      <!-- <router-link :to="{name: 'Contratos'}">
        <a class="btn-floating btn-large waves-effect waves-light red left">
          <i class="material-icons">arrow_back</i>
        </a >
      </router-link>      

      <button class="btn-floating btn-large waves-effect waves-light red right">
        <i class="material-icons">check</i>
      </button> -->

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
        estadoscivis: ['Solteiro(a)','Casado(a)', 'Divorciado(a)']
        }
    },    
    created(){
      this.ApartamentoService = new ApartamentoService(this.$resource);            
      this.ApartamentoService.listarDesocupados().then(x => this.apartamentosDesocupados = x);                           
      this.contratoService = new ContratoService(this.$resource);         
      var selects = document.querySelectorAll('select');
      // eslint-disable-next-line
      M.FormSelect.init(selects);
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


