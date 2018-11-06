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
        Locatário
      </v-tab>

      <v-tab ripple>
        Aluguéis
      </v-tab>

      <v-tab-item>
        <v-card flat>
          <v-card-text>            
            <dl>
              <dt> Data de Início </dt>
              <dd> {{ this.contrato.dataDeInicio }} </dd>

              <dt> Data de Término </dt>
              <dd> {{ this.contrato.dataDeTermino }} </dd>

              <dt> Locatário </dt>
              <dd> {{ contrato.locatario.nome }} </dd>
            </dl>

          </v-card-text>
        </v-card>
      </v-tab-item>

      <v-tab-item>
        <v-card flat>
          <v-card-text>
            Locatário
          </v-card-text>
        </v-card>
      </v-tab-item>

      <v-tab-item>
        <v-card flat>
          <v-card-text>
            Aluguéis
          </v-card-text>
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

  export default {
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
    },
    methods: {
       
    }    
  }
</script>

<style scoped>

</style>


