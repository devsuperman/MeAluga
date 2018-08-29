<template>
    <div>
        <form>
            <v-text-field
            v-validate="'required|max:8'"
            v-model="imovel.endereco.cep"
            :counter="8"
            :error-messages="errors.collect('cep')"
            label="CEP"
            data-vv-name="cep"
            required
            @input="BuscarCEP()"
            ></v-text-field>

            <v-text-field
            v-validate="'required|max:50'"
            v-model="imovel.endereco.rua"
            :counter="50"            
            :error-messages="errors.collect('rua')"
            label="Rua"
            data-vv-name="rua"
            required
            ></v-text-field>

            <v-text-field
            v-validate="'required|max:5'"
            v-model="imovel.endereco.numero"
            :counter="5"
            :error-messages="errors.collect('numero')"
            label="Número"
            data-vv-name="numero"
            required
            ></v-text-field>

            <v-text-field
            v-validate="'required|max:50'"
            v-model="imovel.endereco.bairro"
            :counter="50"
            :error-messages="errors.collect('bairro')"
            label="Bairro"
            data-vv-name="bairro"
            required
            ></v-text-field>


            <v-text-field
            v-validate="'max:50'"
            v-model="imovel.endereco.complemento"
            :counter="50"
            :error-messages="errors.collect('complemento')"
            label="Complemento"
            data-vv-name="complemento"
            required
            ></v-text-field>
            
            <v-btn fab dark color="teal" @click="Voltar">
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
      
      var id = this.$route.params.id;

      if (id) {
        this.service.buscar(id)
          .then(r => this.imovel = r);                
      }
    },
    methods:{
      Salvar(){
        this.$validator.validateAll().then(success => {
            
            if (success) {                                          
              this.service.salvar(this.imovel)
                .then(resposta => {                  
                  var url = {name: 'DetalhesDoImovel', params: {id: resposta.body.id}};
                  this.$router.push(url);
              });              
            }
          });
      },
      Voltar(){
        history.back();
      },
      LimparCampos(){
          this.imovel.endereco.cep = '';
          this.imovel.endereco.rua = '';
          this.imovel.endereco.numero = '';
          this.imovel.endereco.bairro = '';          
          this.imovel.endereco.complemento = '';
      },
      BuscarCEP(){
        if (this.imovel.endereco.cep.length < 8) {
          return;
        }
        
        var validacep = /^[0-9]{8}$/;

        if (!validacep.test(this.imovel.endereco.cep)) {          
          return; 
        }

        var url = "https://viacep.com.br/ws/" + this.imovel.endereco.cep + "/json";

        this.$http.get(url)
          .then(res => res.json())
          .then(endereco => {            
            this.imovel.endereco.rua = endereco.logradouro;
            this.imovel.endereco.bairro = endereco.bairro;
          });                
      }
    }  
  }

</script>

<style scoped>

</style>


