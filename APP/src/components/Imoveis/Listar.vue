<template>
    <div>

      <v-btn
        absolute
        dark
        fab
        top
        right
        color="pink"
        :to="{name: 'CriarImovel'}"        
      >
        <v-icon>add</v-icon>
      </v-btn>

      <v-card>     
        <v-list two-line>
          <template v-for="(imovel, id) in imoveis">
            
            <v-list-tile                    
              :key="id"
              avatar
              @click="$router.push({name: 'DetalhesDoImovel', params:{id: imovel.id}})"
            >
              <v-list-tile-avatar>
                <v-icon>home</v-icon>
              </v-list-tile-avatar>

              <v-list-tile-content>
                <v-list-tile-title >
                  {{imovel.endereco}}
                </v-list-tile-title>
                <v-list-tile-sub-title v-html="imovel.situacao"></v-list-tile-sub-title>
              </v-list-tile-content>
              
            </v-list-tile>
          </template>
        </v-list>
      </v-card>

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
    }   
  }
</script>

<style scoped>

</style>


