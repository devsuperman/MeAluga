import Endereco from "../shared/Endereco";

export default class Imovel{
     
    constructor(endereco = new Endereco())
    {
        this.endereco = endereco;        
    }        
}