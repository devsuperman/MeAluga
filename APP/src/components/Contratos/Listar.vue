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

       <v-card>     
        <v-list two-line>
          <template v-for="(contrato, id) in contratos">
            
            <v-list-tile                    
              :key="id"
              avatar
              @click="$router.push({name: 'DetalhesDoContrato', params: {id: contrato.id}})"
            >
              <v-list-tile-avatar>
                <v-icon>home</v-icon>
              </v-list-tile-avatar>

              <v-list-tile-content>
                <v-list-tile-title >
                  {{contrato.locatario}} - Contrato {{contrato.situacao}}
                </v-list-tile-title>
                <v-list-tile-sub-title v-html="contrato.imovel"></v-list-tile-sub-title>
              </v-list-tile-content>
              
            </v-list-tile>
          </template>
        </v-list>
      </v-card>

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


