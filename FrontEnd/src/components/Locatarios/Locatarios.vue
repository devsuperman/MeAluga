<template>
    <div>

      <v-btn
        absolute
        dark
        fab
        top
        right
        color="pink"
        to="imoveis/new"        
      >
        <v-icon>add</v-icon>
      </v-btn>

        <v-data-table
            :headers="headers"
            :items="imoveis"
            hide-actions
            class="elevation-1"
        >
            <template slot="items" slot-scope="props">              
              <td @click="LinkPara({name: 'DetalhesDoImovel', params:{id: props.item.id}})"> 
                {{ props.item.endereco.rua }},
                {{ props.item.endereco.numero }}, 
                {{ props.item.endereco.bairro }},  
                {{ props.item.endereco.complemento }} 
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
    },
    methods:{
      LinkPara(rota){
        this.$router.push(rota);
      }     
    }
  }
</script>

<style scoped>

</style>


