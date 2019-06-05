import Vue from 'vue';
import pt_BR from 'vee-validate/dist/locale/pt_BR';
import VeeValidate, { Validator } from 'vee-validate';

Validator.localize('pt-BR', pt_BR);

Vue.use(VeeValidate);
