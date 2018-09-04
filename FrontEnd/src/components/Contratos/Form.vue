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
              lazy
              transition="scale-transition"
              offset-y
              full-width
              min-width="290px"
            >
              <v-text-field
                v-validate="'required'"
                :error-messages="errors.collect('contrato.dataDeInicio')"
                data-vv-name="contrato.dataDeInicio"                                           
                label="Data de Início"
                slot="activator"
                v-model="computedDateFormatted"                        
                readonly
              ></v-text-field>

              <v-date-picker 
                no-title
                v-model="date"   
                locale="pt-br"
                @input="menu = false"
              ></v-date-picker>
            </v-menu>            

            <v-radio-group 
              row
              v-model="contrato.duracao" 
              v-validate="'required'"
              :error-messages="errors.collect('contrato.duracao')"
              data-vv-name="contrato.duracao"                   
            >
              <v-radio label="6 Meses" value="6"></v-radio>
              <v-radio label="1 Ano" value="12"></v-radio>
            </v-radio-group>

              <v-text-field
                type='number'                
                v-validate="'required'"
                :error-messages="errors.collect('contrato.valorDoAluguel')"
                data-vv-name="contrato.valorDoAluguel"                                           
                label="Valor do Aluguel"                
                v-model="contrato.valorDoAluguel"                          
              ></v-text-field>


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
        date: null        
        }
    },

    created(){
      this.contratoService = new ContratoService(this.$resource);      
      this.imovelService = new ImovelService(this.$resource);      
      this.locatarioService = new LocatarioService(this.$resource);      
      
      this.imovelService.buscar().then(x => this.imoveis = x);                
      this.locatarioService.buscar().then(x => this.locatarios = x);                      
    },       

     computed: {
      computedDateFormatted () {
        return this.formatDate(this.date)
      }
    },

    watch: {
      date (val) {        
        this.contrato.dataDeInicio = this.formatDate(this.date);           
      }
    },

    methods:{
      formatDate (date) {
        if (!date) return null

        const [year, month, day] = date.split('-')
        return `${day}/${month}/${year}`
      },
      parseDate (date) {
        if (!date) return null

        const [month, day, year] = date.split('/')
        return `${year}-${month.padStart(2, '0')}-${day.padStart(2, '0')}`
      },
      Salvar(){
        this.$validator.validateAll().then(success => {
            
            if (success) {                            
              console.log(this.contrato);
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


