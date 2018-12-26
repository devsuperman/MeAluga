<template>
  <div>
    <form @submit.prevent="Salvar()">
      
      <div class="input-field">
        <input id='apelido' name='apelido' type='text' class="validate" required>
        <label for="apelido">Apelido</label>      
      </div>        

      <div class="input-field">
        <input id='endereco' name='endereco' type='text' class="validate" required :value='imovel.enderecoCompleto'>
        <label for="endereco">Endereço</label>      
      </div>        

      <router-link :to="{name: 'Imoveis'}">
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
import Imovel from "../../domain/imovel/Imovel";
import ImovelService from "../../domain/imovel/ImovelService";

  export default {
    data () {
      return {   
        imovel: new Imovel()        
      }
    },
    created(){
      
      this.service = new ImovelService(this.$resource); 
      
      var id = this.$route.params.id;

      if (id) {
        this.service.buscar(id)
          .then(r => this.imovel = r);                
      }
    },
    methods:{
      Salvar(){        
        this.service.salvar(this.imovel)
          .then(resposta => {                  
            var url = {name: 'DetalhesDoImovel', params: {id: resposta.body.id}};
            this.$router.push(url);
        });                      
      }     
    }  
  }

</script>

<style scoped>

</style>


