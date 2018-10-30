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
            
            </h3>            
          </div>
        </v-card-title>
      </v-card>
       
      <v-layout column align-end> 
            <v-btn fab dark color="teal" :to="{name: 'Contratos'}">
              <v-icon dark>arrow_back</v-icon>
            </v-btn>            
      </v-layout> 
    </v-flex>
  </v-layout>
</template>

<script>
import Contrato from "../../domain/contrato/Contrato";
import ContratoService from "../../domain/contrato/ContratoService";

  export default {
    data () {
      return {   
        contrato: new Contrato()        
      }
    },
    created(){
      this.service = new ContratoService(this.$resource);      
      
      this.service
        .buscar(this.$route.params.id)
        .then(res => {
            this.Contrato = res;   
            console.log(this.contrato);         
          });      
    },
    methods: {
      
    }    
  }
</script>

<style scoped>

</style>


