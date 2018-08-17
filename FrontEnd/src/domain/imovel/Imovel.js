export default class Imovel{
     
    constructor(endereco)
    {
        this.Endereco = endereco;        
    }    

    EnderecoCompleto(){
        return `${this.endereco.rua}, ${this.endereco.numero},`;
    }
}