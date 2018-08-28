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
              {{ locatario.nome }}, {{locatario.cpf}}, {{locatario.rg}}              
            </h3>            
          </div>
        </v-card-title>
      </v-card>
       
      <v-layout column align-end> 
            <v-btn fab dark color="teal" :to="{name: 'Locatarios'}">
              <v-icon dark>arrow_back</v-icon>
            </v-btn>

            <v-btn fab dark color="pink" :to="{name: 'EditarLocatario', params: {id: locatario.id}}">
              <v-icon dark>edit</v-icon>
            </v-btn>

            <v-btn fab dark color="red" @click.stop="dialog = true">
              <v-icon dark>delete_sweep</v-icon>
            </v-btn>
      </v-layout> 
    </v-flex>

     <v-dialog v-model="dialog" max-width="290">
      <v-card>
        <v-card-title class="headline">Excluir Locatário</v-card-title>

        <v-card-text>
          O locatário não poderá ser recuperado! deseja continuar?
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn flat color="teal" @click="dialog = false">
            Nãããão!!!
          </v-btn>

          <v-btn flat color="pink" @click="Excluir()">
            Sim! Exclua!
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

  </v-layout>
</template>

<script>
import Locatario from "../../domain/locatario/Locatario";
import LocatarioService from "../../domain/locatario/LocatarioService";

  export default {
    data () {
      return {   
        locatario: new Locatario(),
        dialog: false        
      }
    },
    created(){
      this.service = new LocatarioService(this.$resource);      
      this.service.buscar(this.$route.params.id).then(res => this.locatario = res);      
    },
    methods: {
      Excluir(){
        var urlDestino = {name: 'Locatarios'};        

        this.service.apagar(this.locatario.id)
          .then(() => this.$router.push(urlDestino));
      }
    }    
  }
</script>

<style scoped>

</style>


