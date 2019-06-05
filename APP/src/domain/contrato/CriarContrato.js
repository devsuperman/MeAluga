import Locatario from "../locatario/Locatario";

export default class CriarContrato{
    
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