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
      </v-card>
       
      <v-layout column align-end> 
            <v-btn fab dark color="teal" :to="{name: 'Imoveis'}">
              <v-icon dark>arrow_back</v-icon>
            </v-btn>

            <v-btn fab dark color="pink" :to="{name: 'EditarImovel', params: {id: imovel.id}}">
              <v-icon dark>edit</v-icon>
            </v-btn>

            <v-btn fab dark color="red" @click.stop="dialog = true">
              <v-icon dark>delete_sweep</v-icon>
            </v-btn>
      </v-layout> 
    </v-flex>

     <v-dialog v-model="dialog" max-width="290">
      <v-card>
        <v-card-title class="headline">Excluir Imóvel</v-card-title>

        <v-card-text>
          O imóvel não poderá ser recuperado! deseja continuar?
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
import Imovel from "../../domain/imovel/Imovel";
import ImovelService from "../../domain/imovel/ImovelService";

  export default {
    data () {
      return {   
        imovel: new Imovel(),
        dialog: false        
      }
    },
    created(){
      this.service = new ImovelService(this.$resource);      
      this.service.buscar(this.$route.params.id).then(res => this.imovel = res);
    },
    methods: {
      Excluir(){
        var urlDestino = {name: 'Imoveis'};        
        this.service.apagar(this.imovel.id)
          .then(() => this.$router.push(urlDestino));
      }
    }    
  }
</script>

<style scoped>

</style>


