<template>
    <div>

    </div>
</template>

<script>

  import ContratoService from '../../domain/Contrato/ContratoService';
  
  export default {
    data () {
      return {   
        msg: false,     
        headers: [
          { text: 'Locatário', value: 'locatario' },
          { text: 'Imóvel', value: 'imovel' },
          { text: 'Situação', value: 'situacao' }
        ],
        contratos: []
      }
    },
    created(){
      this.service = new ContratoService(this.$resource);      
      this.service.listar().then(res => this.contratos = res);
    }
  }
</script>

<style scoped>

</style>


