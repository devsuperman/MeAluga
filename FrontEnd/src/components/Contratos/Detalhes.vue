<template>
  <div>
    <v-tabs      
      color="cyan"
      dark
      slider-color="yellow">

      <v-tab ripple>
        Contrato
      </v-tab>
   
      <v-tab ripple>
        Aluguéis
      </v-tab>

      <v-tab-item>
        <v-card flat>

        <v-list two-line>
          <v-list-tile>
            <v-list-tile-action>
              <v-icon color="indigo">person</v-icon>
            </v-list-tile-action>

            <v-list-tile-content>
              <v-list-tile-title>{{this.contrato.locatario.nome}}</v-list-tile-title>
              <v-list-tile-sub-title>Locatário</v-list-tile-sub-title>
            </v-list-tile-content>            
          </v-list-tile>

          <v-divider inset></v-divider>

           <v-list-tile>
            <v-list-tile-action>
              <v-icon color="indigo">home</v-icon>
            </v-list-tile-action>

            <v-list-tile-content>
              <v-list-tile-title>{{this.contrato.imovel.enderecoCompleto}}</v-list-tile-title>
              <v-list-tile-sub-title>Imóvel</v-list-tile-sub-title>
            </v-list-tile-content>            
          </v-list-tile>

          <v-divider inset></v-divider>

          <v-list-tile>
            <v-list-tile-action>
              <v-icon color="indigo">date_range</v-icon>
            </v-list-tile-action>

            <v-list-tile-content>
              <v-list-tile-title>
                {{ new Date(this.contrato.dataDeInicio).toLocaleDateString() }}  à
                {{ new Date(this.contrato.dataDeTermino).toLocaleDateString() }}
              </v-list-tile-title>
              <v-list-tile-sub-title>Vigência</v-list-tile-sub-title>
            </v-list-tile-content>            
          </v-list-tile>


          <v-divider inset></v-divider>

          <v-list-tile>
            <v-list-tile-action>
              <v-icon color="indigo">attach_money</v-icon>
            </v-list-tile-action>

            <v-list-tile-content>
              <v-list-tile-title>                
                R${{ this.contrato.valor }}
              </v-list-tile-title>
              <v-list-tile-sub-title>Valor</v-list-tile-sub-title>
            </v-list-tile-content>            
          </v-list-tile>
        </v-list>
        
        </v-card>
      </v-tab-item>
    
      <v-tab-item>
        <v-card flat>
          <alugueis :alugueis="contrato.alugueis"></alugueis>                      
        </v-card>
      </v-tab-item>
      
    </v-tabs>

       
    <v-layout column align-end> 
          <v-btn fab dark color="teal" :to="{name: 'Contratos'}">
            <v-icon dark>arrow_back</v-icon>
          </v-btn>            
    </v-layout> 
    
  </div>
</template>

<script>
import Contrato from "../../domain/contrato/Contrato";
import ContratoService from "../../domain/contrato/ContratoService";
import Alugueis from "./Alugueis";

  export default {
    components:{
      'alugueis': Alugueis
    },
    data () {
      return {   
        contrato: new Contrato()        
      }
    },
    created(){
      this.service = new ContratoService(this.$resource);      
      
      this.service
        .buscar(this.$route.params.id)
        .then(res => this.contrato = res);      
    }    
  }
</script>

<style scoped>

</style>


