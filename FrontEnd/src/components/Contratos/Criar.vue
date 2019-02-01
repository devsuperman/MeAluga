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
        <input id='valor' type='number' class="validate" required v-model='contrato.ValorDoAluguel'>
        <label for="valor" class='active'>Valor</label>      
      </div>  


      <label>Apartamento</label>
      <select class="browser-default" v-model="contrato.ApartamentoId">
        <option value='' selected> Selecione </option>
        <option v-for="ap in apartamentosDesocupados" :key="ap.id" :value='ap.id'> {{ ap.apelido }}</option>                              
      </select>

      <br>

      <h4>
        😃 Locatário
      </h4>
      <hr>
      <div class="input-field">
        <input id='locatario.Nome' type='text' class="validate" required v-model='contrato.locatario.Nome'>
        <label for="locatario.Nome" class='active'>Nome</label>      
      </div>
     
      <div class="input-field">
        <input id='locatario.CPF' type='text'  class="validate" required v-model='contrato.locatario.CPF'>
        <label for="locatario.CPF" class='active'>CPF</label>                
      </div>

      <div class="input-field">
        <input id='locatario.RG' type='text'  class="validate" v-model='contrato.locatario.RG'>
        <label for="locatario.RG" class='active'>RG</label>                
      </div>

      <div class="input-field">
        <input id='locatario.Profissao'  type='text' class="validate" v-model='contrato.locatario.Profissao'>
        <label for="locatario.Profissao" class='active'>Profissão</label>                
      </div>

      <div class="input-field">
        <input id='locatario.Nacionalidade' type='text'  class="validate" v-model='contrato.locatario.Nacionalidade'>
        <label for="locatario.Nacionalidade" class='active'>Nacionalidade</label>                
      </div>

      <div class="input-field">
        <input id='locatario.Telefone'  type='text' class="validate" v-model='contrato.locatario.Telefone'>
        <label for="locatario.Telefone" class='active'>Telefone</label>                
      </div>

      <label>Estado Civil</label>
      <select class="browser-default" v-model='contrato.locatario.estadoCivil'>    
        <option value=''> Selecione </option>      
        <option v-for="estado in estadoscivis" :key="estado" :value='estado'> {{ estado }}</option>                              
      </select>
      

      <router-link :to="{name: 'Contratos'}">
        <a class="btn-floating btn-large waves-effect waves-light blue left">
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
        estadoscivis: ['Solteiro(a)','Casado(a)', 'Divorciado(a)']
        }
    },    
    created(){
      this.ApartamentoService = new ApartamentoService(this.$resource);            
      this.ApartamentoService.listarDesocupados().then(x => this.apartamentosDesocupados = x);                           
      this.contratoService = new ContratoService(this.$resource);         
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


