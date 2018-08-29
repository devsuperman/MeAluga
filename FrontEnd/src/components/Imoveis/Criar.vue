<template>
    <div>
        <form>
            <v-text-field
            v-validate="'required|max:8'"
            v-model="endereco.CEP"
            :counter="8"
            :error-messages="errors.collect('cep')"
            label="CEP"
            data-vv-name="cep"
            required
            @input="BuscarCEP"
            ></v-text-field>

            <v-text-field
            v-validate="'required|max:50'"
            v-model="endereco.Rua"
            :counter="50"
            :error-messages="errors.collect('rua')"
            label="Rua"
            data-vv-name="rua"
            required
            ></v-text-field>

            <v-text-field
            v-validate="'required|max:5'"
            v-model="endereco.Numero"
            :counter="5"
            :error-messages="errors.collect('numero')"
            label="Número"
            data-vv-name="numero"
            required
            ></v-text-field>

            <v-text-field
            v-validate="'required|max:50'"
            v-model="endereco.Bairro"
            :counter="50"
            :error-messages="errors.collect('bairro')"
            label="Bairro"
            data-vv-name="bairro"
            required
            ></v-text-field>


            <v-text-field
            v-validate="'max:50'"
            v-model="endereco.Complemento"
            :counter="50"
            :error-messages="errors.collect('complemento')"
            label="Complemento"
            data-vv-name="complemento"
            required
            ></v-text-field>
            
            <v-btn fab dark color="teal" :to="{name: 'Imoveis'}">
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
import Endereco from "../../domain/shared/Endereco";
import Imovel from "../../domain/imovel/Imovel";
import ImovelService from "../../domain/imovel/ImovelService";

  export default {
    data () {
      return {   
        endereco: new Endereco()        
      }
    },
    created(){
      this.service = new ImovelService(this.$resource);      
    },
    methods:{
      Salvar(){
        this.$validator.validateAll().then(success => {
            
            if (success) {                            
              
              var imovel = new Imovel(this.endereco);                                              
              
              this.service.salvar(imovel)
                .then(resposta => {                  
                  var url = {name: 'DetalhesDoImovel', params: {id: resposta.body.id}};                
                  this.$router.push(url);
              });
              
            }
          });
      },
      LimparCampos(){
          this.endereco.CEP = '';
          this.endereco.Rua = '';
          this.endereco.Numero = '';
          this.endereco.Bairro = '';          
          this.endereco.Complemento = '';
      },
      BuscarCEP(){
        
        if (this.endereco.CEP.length < 8) {
          return;
        }
        
        var validacep = /^[0-9]{8}$/;

        if (!validacep.test(this.endereco.CEP)) {          
          return; 
        }

        var url = "https://viacep.com.br/ws/" + this.endereco.CEP + "/json";

        this.$http.get(url)
          .then(res => res.json())
          .then(endereco => {            
            this.endereco.Rua = endereco.logradouro;
            this.endereco.Bairro = endereco.bairro;
          });                
      }
    }
  
  }

</script>

<style scoped>

</style>


