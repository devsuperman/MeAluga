export default class Endereco{
    
    constructor(cep = '', logradouro = '', bairro = '', numero = '', complemento = '')
    {
        this.cep = cep;        
        this.logradouro = logradouro;
        this.bairro = bairro;
        this.numero = numero;
        this.complemento = complemento;
    }

}