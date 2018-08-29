<template>
    <div>

      <v-btn
        absolute
        dark
        fab
        top
        right
        color="pink"
        :to="{name: 'CriarLocatario'}"                
      >
        <v-icon>add</v-icon>
      </v-btn>

        <v-data-table
            :headers="headers"
            :items="locatarios"
            hide-actions
            class="elevation-1"
        >
            <template slot="items" slot-scope="props">
              <td> 
                <router-link :to="{name: 'DetalhesDoLocatario', params:{id:props.item.id}}">
                  {{ props.item.nome }}                                  
                </router-link>
              </td>
              <td> {{ props.item.cpf }} </td>            
              <td> {{ props.item.rg }} </td>
            </template>

            <template slot="no-data" slot-scope="props">              
              <v-alert :value="true" color="error" icon="warning">
                Desculpe, nada para mostrar aqui :(
              </v-alert>          
            </template>

        </v-data-table>

    </div>
</template>

<script>

  import LocatarioService from '../../domain/locatario/LocatarioService';

  export default {
    data () {
      return {   
        msg: false,     
        headers: [
          { text: 'Nome', value: 'nome' },
          { text: 'CPF', value: 'cpf' },
          { text: 'RG', value: 'rg' }                                
        ],
        locatarios: []
      }
    },
    created(){
      this.service = new LocatarioService(this.$resource);      
      this.service.listar().then(res => this.locatarios = res);
    }
  }
  
</script>

<style scoped>

</style>


