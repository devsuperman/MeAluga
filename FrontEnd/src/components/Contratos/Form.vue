<template>
    
        <form>          
         
        </form>
  
</template>

<script>
import CriarContrato from "../../domain/Contrato/CriarContrato";
import ContratoService from "../../domain/Contrato/ContratoService";
import ApartamentoService from "../../domain/Apartamento/ApartamentoService";

  export default {
    data () {
      return {   
        contrato: new CriarContrato(),                
        apartamentos: [],        
        estadoscivis: ['Solteiro (a)','Casado (a)']
        }
    },

    created(){
      this.contratoService = new ContratoService(this.$resource);      
      this.ApartamentoService = new ApartamentoService(this.$resource);            
      this.ApartamentoService.listarDisponiveis().then(x => this.imoveis = x);                
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


