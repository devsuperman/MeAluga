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
            v-validate="'max:20'"
            v-model="locatario.rg"
            :counter="20"
            :error-messages="errors.collect('rg')"
            label="RG"
            data-vv-name="rg"
            required
            ></v-text-field>  

            <v-text-field
            v-validate="'max:50'"
            v-model="locatario.profissao"
            :counter="50"
            :error-messages="errors.collect('profissao')"
            label="Profissão"
            data-vv-name="profissao"
            required
            ></v-text-field>  

            <v-text-field
            v-validate="'max:50'"
            v-model="locatario.nacionalidade"
            :counter="50"
            :error-messages="errors.collect('nacionalidade')"
            label="Nacionalidade"
            data-vv-name="nacionalidade"
            required
            ></v-text-field>  

            <v-select 
                  v-model="locatario.EstadoCivil"
                  :items="estadoscivis"                  
                  v-validate="'required'"
                  :error-messages="errors.collect('locatario.EstadoCivil')"
                  label="Estado Civil"
                  data-vv-name="locatario.EstadoCivil"   
                ></v-select>

            <v-text-field
            v-validate="'max:15'"
            v-model="locatario.telefone"
            :counter="15"
            :mask="mascaraDeTelefone"
            :error-messages="errors.collect('telefone')"
            label="Telefone"
            data-vv-name="telefone"
            required
            ></v-text-field>  
      
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

  export default {
    data () {
      return {   
        locatario: new Locatario(),
        estadoscivis: ['Solteiro (a)','Casado (a)'],
        mascaraDeTelefone: '(##) ##### - ####',     
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


