import Locatario from "../locatario/Locatario";

export default class Contrato{
    
    constructor()
    {
        this.imovelId = '';
        this.locatario = '';        
        this.dataDeInicio = '';  
        this.duracao = '';
        this.valorDoAluguel = '';
        this.locatario = new Locatario();
    }

}