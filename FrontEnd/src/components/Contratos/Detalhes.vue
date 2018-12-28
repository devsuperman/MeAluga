<template>
  <div>
   
  </div>
</template>

<script>
import Contrato from "../../domain/Contrato/Contrato";
import ContratoService from "../../domain/Contrato/ContratoService";

  export default {
    data () {
      return {   
        contrato: new Contrato()        
      }
    },
    created(){
      this.service = new ContratoService(this.$resource);      
      
      this.service
        .buscar(this.$route.params.id)
        .then(res => this.contrato = res);      
    }        
  }
</script>

<style scoped>

</style>


