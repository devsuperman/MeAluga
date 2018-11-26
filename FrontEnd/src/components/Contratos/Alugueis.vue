<template>
<div>

     <v-list two-line>
          <template v-for="(item, index) in alugueis">
            <v-list-tile
              :key="index"
              avatar
              ripple
              @click="AbrirJanelaParaEfetuarPagamento(item)"
            >
              <v-list-tile-content>
                
                <v-list-tile-title>
                    {{ new Date(item.vencimento).toLocaleDateString() }}
                </v-list-tile-title>
                
                <v-list-tile-sub-title class="text--primary" v-if='item.dataDePagamento !== null'>  
                    <v-icon color="green darken-2"> check_circle </v-icon>                
                    Pago em {{item.dataDePagamento}}
                </v-list-tile-sub-title>

              </v-list-tile-content>
            </v-list-tile>
            
            <v-divider v-if="index + 1 < alugueis.length" :key="index"></v-divider>

          </template>
        </v-list>

        <v-layout row justify-center>
            <v-dialog v-model="dialog" persistent max-width="600px">
            
            <v-card>
                <v-card-title>
                <span class="headline">
                <v-icon color="indigo">attach_money</v-icon>
                    Registrar Pagamento
                </span>
                </v-card-title>
                <v-card-text>
                
                        <v-text-field                        
                        :value="new Date(aluguel.vencimento).toLocaleDateString()"
                        readonly                       
                        label="Vencimento"
                        ></v-text-field>

                        <v-text-field                        
                        v-model="aluguel.valor"
                        readonly         
                        label="Valor"              
                        ></v-text-field>

                        <v-text-field
                        v-validate="'required'"
                        v-model="aluguel.valorPago"                        
                        :error-messages="errors.collect('valorPago')"
                        label="Valor Pago"
                        data-vv-name="valorPago"
                        required
                        ></v-text-field>

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
                                :error-messages="errors.collect('aluguel.dataDePagamento')"
                                data-vv-name="aluguel.dataDePagamento"                                           
                                label="Data de Pagamento"
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

                        <v-text-field
                        v-validate="'max:500'"
                        v-model="aluguel.observacao"                        
                        :error-messages="errors.collect('observacao')"
                        label="Observação"
                        :counter="500"
                        data-vv-name="observacao"
                        required
                        ></v-text-field>                  
                    
                
                </v-card-text>
                <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" flat @click="dialog = false">Cancelar</v-btn>
                <v-btn color="blue darken-1" flat @click="dialog = false">Salvar</v-btn>
                </v-card-actions>
            </v-card>
            </v-dialog>
        </v-layout>
</div>

</template>

<script>
import Aluguel from "../../domain/aluguel/Aluguel";

export default {
    props:['alugueis'],
    data: () => ({
        dialog: false,
        aluguel: new Aluguel(),
        menu: false,
        date: null
    }),
     computed: {
      computedDateFormatted () {
        return this.formatDate(this.date)
      }
    },
    watch: {
      date () {        
        this.aluguel.dataDePagamento = this.formatDate(this.date);           
      }
    },
    methods:{
        formatDate (date) {
        if (!date) return null

        const [year, month, day] = date.split('-')
        return `${day}/${month}/${year}`
      },
        AbrirJanelaParaEfetuarPagamento(aluguel){
            if (aluguel.dataDePagamento == null) {
                this.dialog = true;
                this.aluguel = aluguel;
            }            
        }
    }  
}
</script>

