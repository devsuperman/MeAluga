<template>
    <div>
        <form>
            <v-text-field
            v-validate="'required|max:50'"
            v-model="locatario.nome"
            :counter="50"
            :error-messages="errors.collect('nome')"
            label="Nome"
            data-vv-name="nome"
            required            
            ></v-text-field>

            <v-text-field
            v-validate="'required|max:11'"
            v-model="locatario.cpf"
            :counter="11"
            :error-messages="errors.collect('cpf')"
            label="CPF"
            data-vv-name="cpf"
            required
            ></v-text-field>

            <v-text-field
            v-validate="'required|max:20'"
            v-model="locatario.rg"
            :counter="20"
            :error-messages="errors.collect('rg')"
            label="RG"
            data-vv-name="rg"
            required
            ></v-text-field>
      
            <v-btn fab dark color="teal" :to="{name: 'Locatarios'}">
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

  export default {
    data () {
      return {   
        locatario: new Locatario()        
      }
    },
    created(){
      this.service = new LocatarioService(this.$resource);      
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


