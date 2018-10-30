<template>
    <div>
        <form>
          
          <v-stepper v-model="step" vertical> 
            <v-stepper-step :complete="step > 1" step="1" editable>
              Locatário              
            </v-stepper-step>

            <v-stepper-content step="1">             
              
              <v-text-field
              v-validate="'required|max:50'"
              v-model="contrato.locatario.nome"
              :counter="50"
              :error-messages="errors.collect('contrato.locatario.nome')"
              label="Nome"
              data-vv-name="contrato.locatario.nome"
              required            
              ></v-text-field>

              <v-text-field
              v-validate="'required|max:11'"
              v-model="contrato.locatario.cpf"
              :counter="11"
              :error-messages="errors.collect('contrato.locatario.cpf')"
              label="CPF"
              data-vv-name="contrato.locatario.cpf"
              required
              ></v-text-field>

              <v-text-field
              v-validate="'max:20'"
              v-model="contrato.locatario.rg"
              :counter="20"
              :error-messages="errors.collect('contrato.locatario.rg')"
              label="RG"
              data-vv-name="contrato.locatario.rg"
              required
              ></v-text-field>  

              <v-text-field
              v-validate="'max:50'"
              v-model="contrato.locatario.profissao"
              :counter="50"
              :error-messages="errors.collect('contrato.locatario.profissao')"
              label="Profissão"
              data-vv-name="contrato.locatario.profissao"
              required
              ></v-text-field>  

              <v-text-field
              v-validate="'max:50'"
              v-model="contrato.locatario.nacionalidade"
              :counter="50"
              :error-messages="errors.collect('contrato.locatario.nacionalidade')"
              label="Nacionalidade"
              data-vv-name="contrato.locatario.nacionalidade"
              required
              ></v-text-field>  

              <v-select 
                    v-model="contrato.locatario.EstadoCivil"
                    :items="estadoscivis"                  
                    v-validate="'required'"
                    :error-messages="errors.collect('contrato.locatario.EstadoCivil')"
                    label="Estado Civil"
                    data-vv-name="contrato.locatario.EstadoCivil"   
                  ></v-select>

              <v-text-field
              v-validate="'max:15'"
              v-model="contrato.locatario.telefone"
              :counter="15"
              :mask="mascaraDeTelefone"
              :error-messages="errors.collect('contrato.locatario.telefone')"
              label="Telefone"
              data-vv-name="contrato.locatario.telefone"
              required
              ></v-text-field>  

              <v-btn color="primary" @click="step = 2">Próximo</v-btn>

            </v-stepper-content>

            <v-stepper-step :complete="step > 2" step="2" editable> Imóvel </v-stepper-step>

            <v-stepper-content step="2" >              
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
              <v-btn color="primary" @click="step = 3">Próximo</v-btn>
              
            </v-stepper-content>

            <v-stepper-step :complete="step > 3" step="3" editable> Contrato </v-stepper-step>

            <v-stepper-content step="3">
              
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

              <v-btn color="primary" @click="Salvar">Salvar</v-btn>
              
            </v-stepper-content>            
          </v-stepper>

            <v-btn fab dark color="teal" @click="VoltarParaPaginaAnterior()">
              <v-icon dark>arrow_back</v-icon>
            </v-btn>

        </form>

    </div>
</template>

<script>
import Contrato from "../../domain/contrato/Contrato";
import Locatario from "../../domain/locatario/Locatario";
import ContratoService from "../../domain/contrato/ContratoService";
import ImovelService from "../../domain/imovel/ImovelService";
import LocatarioService from "../../domain/locatario/LocatarioService";

  export default {
    data () {
      return {   
        contrato: new Contrato(),                
        imoveis: [],
        menu: false,
        date: null,
        step: 1,
        estadoscivis: ['Solteiro (a)','Casado (a)'],
        mascaraDeTelefone: '(##) ##### - ####'             
        }
    },

    created(){
      this.contratoService = new ContratoService(this.$resource);      
      this.imovelService = new ImovelService(this.$resource);      
      this.locatarioService = new LocatarioService(this.$resource);      
      
      this.imovelService.listarDisponiveis().then(x => this.imoveis = x);                
      this.locatarioService.listar().then(x => this.locatarios = x);                      
    },       

     computed: {
      computedDateFormatted () {
        return this.formatDate(this.date)
      }
    },

    watch: {
      date () {        
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
        console.log(this.contrato);
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


