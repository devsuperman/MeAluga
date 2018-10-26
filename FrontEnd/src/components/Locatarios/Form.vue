<template>
    <div>
        <form>
            <form-locatario></form-locatario>
      
            <v-btn fab dark color="teal" @click="history.back();">
              <v-icon dark>arrow_back</v-icon>
            </v-btn>

            <v-btn
              absolute
              dark
              fab              
              right
              color="pink"
              @click="Salvar"
            >
              <v-icon>check</v-icon>
            </v-btn>
        </form>

    </div>
</template>

<script>
import Locatario from "../../domain/locatario/Locatario";
import LocatarioService from "../../domain/locatario/LocatarioService";
import FormLocatario from "./FormLocatario";

  export default {
    components: {
      'form-locatario': FormLocatario
    },
    data () {
      return {   
        locatario: new Locatario()        
      }
    },
    created(){
      this.service = new LocatarioService(this.$resource);      
      
      var id = this.$route.params.id;

      if (id) {
        this.service.buscar(this.$route.params.id)
          .then(x => this.locatario = x);                
      }
    },
    methods:{
      Salvar(){
        this.$validator.validateAll().then(success => {
            
            if (success) {                                          
              this.service.salvar(this.locatario)
                .then(resposta => {                  
                  var url = {name: 'DetalhesDoLocatario', params: {id: resposta.body.id}};                
                  this.$router.push(url);                  
                });              
              }
            });
          }      
        }
  }

</script>

<style scoped>

</style>


