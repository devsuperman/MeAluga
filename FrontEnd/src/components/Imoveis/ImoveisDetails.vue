<template>
  <v-layout>
    <v-flex xs12 sm6 offset-sm3>
      <v-card>
        
        <v-card-media
          src="https://cdn.vuetifyjs.com/images/cards/desert.jpg"
          height="200px"
        >        
        </v-card-media>

        <v-card-title primary-title>
          <div>
            <h3 class="headline mb-0"> 
              {{ imovel.endereco.rua }}, {{imovel.endereco.numero}}, {{imovel.endereco.bairro}}, 
              {{imovel.endereco.complemento}}, {{imovel.endereco.cep}}
            </h3>            
          </div>
        </v-card-title>
       
        <v-btn fab dark color="teal" top absolute :to="{name: 'Imoveis'}">
          <v-icon dark>arrow_back</v-icon>
        </v-btn>

        <v-btn fab dark color="pink" right top absolute :to="{name: 'EditarImovel', params: {id: imovel.id}}">
          <v-icon dark>edit</v-icon>
        </v-btn>

      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import Imovel from "../../domain/imovel/Imovel";
import ImovelService from "../../domain/imovel/ImovelService";

  export default {
    data () {
      return {   
        imovel: new Imovel()
      }
    },
    created(){
      this.service = new ImovelService(this.$resource);      
      this.service.buscar(this.$route.params.id).then(res => this.imovel = res);
    }    
  }
</script>

<style scoped>

</style>


