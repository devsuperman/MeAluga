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

  import ApartamentoService from '../../domain/Apartamento/ApartamentoService';

  export default {
    data () {
      return {   
        msg: false,     
        headers: [
          { text: 'Endereço', value: 'endereco' },
          { text: 'Apelido', value: 'apelido' },
          { text: 'Situação', value: 'situacao' }
        ],
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


