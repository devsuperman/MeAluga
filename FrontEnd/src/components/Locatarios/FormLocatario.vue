<template>
    <div>
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
              v-model="locatario.EstadoCivilId"
              :items="estadosCivis"
              item-text="descricao"
              item-value="id"
              v-validate="'required'"
              :error-messages="errors.collect('locatario.EstadoCivilId')"
              label="Estado Civil"
              data-vv-name="locatario.EstadoCivilId"   
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

    </div>
</template>

<script>
import Locatario from "../../domain/locatario/Locatario";
import EstadoCivilService from "../../domain/estadoCivil/EstadoCivilService";

export default {
    data(){
        return{
            estadoscivis: [],
            mascaraDeTelefone: '(##) ##### - ####',
            locatario: new Locatario()
        }
    },    
    created(){
        this.estadoCivilService = new EstadoCivilService(this.$resource);
        this.estadoCivilService.listar().then(x => this.estadoscivis = x);
    }
}
</script>

<style scoped>

</style>



