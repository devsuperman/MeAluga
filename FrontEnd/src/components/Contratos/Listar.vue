<template>
    <div>
      <ul class="collection">      
          <li class="collection-item" v-for="item in contratos" :key='item.id'>
            <router-link :to="{name: 'Contrato', params:{id:item.id}}">
              {{item.locatario.nome}} - <strong> {{item.apartamento.apelido}} </strong>        
            </router-link>  
          </li>             
      </ul>

       <router-link :to="{name: 'CriarContrato'}">
        <a class="btn-floating btn-large waves-effect waves-light red right">
          <i class="material-icons">add</i>
        </a >
      </router-link> 
    </div>
</template>

<script>

  import ContratoService from '../../domain/contrato/ContratoService';
  
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


