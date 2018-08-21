export default class Endereco{
    
    constructor(cep = '', rua = '', bairro = '', numero = '', complemento = '')
    {
        this.cep = cep;        
        this.rua = rua;
        this.bairro = bairro;
        this.numero = numero;
        this.complemento = complemento;
    }

}