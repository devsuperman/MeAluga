<template>
    <div>
        <form>
            <v-select 
              v-model="contrato.locatarioId"
              :items="locatarios"
              item-text="nome"
              item-value="id"
              v-validate="'required'"
              :error-messages="errors.collect('contrato.locatarioId')"
              label="Locatário"
              data-vv-name="contrato.locatarioId"   
            ></v-select>

            <v-select 
              v-model="contrato.imovelId"
              :items="imoveis"
              item-text="endereco"
              item-value="id"
              v-validate="'required'"
              :error-messages="errors.collect('contrato.imovelId')"
              label="Imóvel"
              data-vv-name="contrato.imovelId"   
            ></v-select>
            
            <v-menu
              ref="menu"
              :close-on-content-click="false"
              v-model="menu"
              :nudge-right="40"
              :return-value.sync="contrato.dataDeInicio"
              lazy
              transition="scale-transition"
              offset-y
              full-width
              min-width="290px"
            >
              <v-text-field
                v-validate="'required'"
                :error-messages="errors.collect('contrato.dataDeInicio')"
                label="Data de Inicio"
                data-vv-name="contrato.dataDeInicio"                                           
                slot="activator"
                v-model="contrato.dataDeInicio"          
                prepend-icon="event"
                readonly
              ></v-text-field>
              <v-date-picker 
                v-model="contrato.dataDeInicio" 
                @input="$refs.menu.save(FormatarData(contrato.dataDeInicio))"
                locale="pt-br"
              ></v-date-picker>
            </v-menu>            
                          
            <v-btn fab dark color="teal" @click="VoltarParaPaginaAnterior()">
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
import Contrato from "../../domain/contrato/Contrato";
import ContratoService from "../../domain/contrato/ContratoService";
import ImovelService from "../../domain/imovel/ImovelService";
import LocatarioService from "../../domain/locatario/LocatarioService";

  export default {
    data () {
      return {   
        contrato: new Contrato(),
        locatarios: [],
        imoveis: [],
        menu: false,
        modal: false
      }
    },
    created(){
      this.contratoService = new ContratoService(this.$resource);      
      this.imovelService = new ImovelService(this.$resource);      
      this.locatarioService = new LocatarioService(this.$resource);      
      
      this.imovelService.buscar().then(x => this.imoveis = x);                
      this.locatarioService.buscar().then(x => this.locatarios = x);                

      //Talvez isso não seja mais utilizado
      // var id = this.$route.params.id;

      // if (id) {
      //   this.contratoService.buscar(this.$route.params.id)
      //     .then(x => this.contrato = x);                
      // }
    },    
    methods:{
      FormatarData(date){
        if (!date) return null;

        const [year, month, day] = date.split('-');

        return `${day}/${month}/${year}`;
      },
      Salvar(){
        this.$validator.validateAll().then(success => {
            
            if (success) {                            
              
              this.contratoService.salvar(this.contrato)
                .then(resposta => {                  
                  var url = {name: 'DetalhesDoContrato', params: {id: resposta.body.id}};                
                  this.$router.push(url);
                  
              });
              
            }
          });
      },
      VoltarParaPaginaAnterior(){
        history.back();
      }
    }
  }

</script>

<style scoped>

</style>


