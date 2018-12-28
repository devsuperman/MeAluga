<template>
  <div>
    <form @submit.prevent="Salvar()">
      
      <input type='hidden' :value='apartamento.id'>

      <div class="input-field">
        <input id='apelido' type='text' class="validate" required v-model='apartamento.apelido'>
        <label for="apelido" class='active'>Apelido</label>      
      </div>        

      <div class="input-field">
        <input id='endereco' type='text' class="validate" required v-model='apartamento.endereco'>
        <label for="endereco" class='active'>Endereço</label>      
      </div>        

      <router-link :to="{name: 'Apartamentos'}">
        <a class="btn-floating btn-large waves-effect waves-light red left">
          <i class="material-icons">arrow_back</i>
        </a >
      </router-link>      

      <button class="btn-floating btn-large waves-effect waves-light red right">
        <i class="material-icons">check</i>
      </button>

    </form>
  </div>  
</template>

<script>
import Apartamento from "../../domain/Apartamento/Apartamento";
import ApartamentoService from "../../domain/Apartamento/ApartamentoService";

  export default {
    data () {
      return {   
        apartamento: new Apartamento()        
      }
    },
    created(){
      
      this.service = new ApartamentoService(this.$resource);       
      var id = this.$route.params.id;

      if (id) {
        this.service.buscar(id)
          .then(r => {
            this.apartamento = r;
          });                      
      }
    },
    methods:{
      Salvar(){        
        this.service.salvar(this.apartamento)
          .then(() => this.$router.push({name: 'Apartamentos'}));                      
      }     
    }  
  }

</script>

<style scoped>

</style>


