<template>
    
    <ul class="collection">      

        <li class="collection-item" v-for="item in imoveis" :key='item.id'>
          <router-link :to="{name: 'EditarImovel', params:{id:item.id}}">
            {{item.endereco}} - <strong> {{item.situacao}} </strong>        
          </router-link>  
        </li>     
        
    </ul>
    
</template>

<script>

  import ImovelService from '../../domain/imovel/ImovelService';

  export default {
    data () {
      return {   
        msg: false,     
        headers: [
          { text: 'Endereço', value: 'endereco' },
          { text: 'Situação', value: 'situacao' }                
        ],
        imoveis: []
      }
    },
    created(){
      this.service = new ImovelService(this.$resource);      
      this.service.listar().then(res => this.imoveis = res);
    }
  }
</script>

<style scoped>

</style>


