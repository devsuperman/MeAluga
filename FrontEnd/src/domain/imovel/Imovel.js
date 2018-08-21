import Endereco from "../shared/Endereco";

export default class Imovel{
     
    constructor(endereco = new Endereco())
    {
        this.Endereco = endereco;        
    }    

    EnderecoCompleto(){
        return `${this.endereco.rua}, ${this.endereco.numero},`;
    }
}