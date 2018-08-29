<template>
    <div>

      <v-btn
        absolute
        dark
        fab
        top
        right
        color="pink"
        :to="{name: 'CriarContrato'}"        
      >
        <v-icon>add</v-icon>
      </v-btn>

        <v-data-table
            :headers="headers"
            :items="contratos"
            hide-actions
            class="elevation-1"
        >
            <template slot="items" slot-scope="props">              
              <td> 
                <router-link :to="{name: 'DetalhesDoContrato', params:{id:props.item.id}}">
                  <!-- {{ props.item.endereco.rua }}                   -->
                </router-link>
              </td>
              <td> {{ props.item.situacao }} </td>            
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


