<template>
    <div>

      <v-btn
        absolute
        dark
        fab
        top
        right
        color="pink"
        @click.native="LinkPara('imoveis/new')"
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
              <td> {{ props.item.endereco }} </td>
              <td> {{ props.item.situacao }} </td>            
            </template>
        </v-data-table>

    </div>
</template>

<script>
  export default {
    data () {
      return {   
        msg: false,     
        headers: [
          { text: 'Endereço', value: 'endereco' },
          { text: 'Situação', value: 'situacao' }                
        ],
        imoveis: [
          {
            endereco: 'rua jatuarana, 1200',
            situacao: 'Desocupado'
          },
          {
            endereco: 'rua jatuarana, 1500',
            situacao: 'Alugado para Tiago Bernardo'
          },
        ]
      }
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


