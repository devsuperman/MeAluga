<template>
    <div>
    
      <ul class="collection">      
          <li class="collection-item" v-for="item in apartamentos" :key='item.id'>
            <router-link :to="{name: 'EditarApartamento', params:{id:item.id}}">
              {{item.apelido}} - <strong> {{item.situacao}} </strong>        
            </router-link>  
          </li>             
      </ul>

       <router-link :to="{name: 'CriarApartamento'}">
        <a class="btn-floating btn-large waves-effect waves-light red right">
          <i class="material-icons">add</i>
        </a >
      </router-link> 

    </div>
    
</template>

<script>

  import ApartamentoService from '../../domain/apartamento/ApartamentoService';

  export default {
    data () {
      return {           
        apartamentos: []
      }
    },
    created(){
      this.service = new ApartamentoService(this.$resource);      
      this.service.listar().then(res => this.apartamentos = res);
    }
  }
</script>

<style scoped>

</style>


