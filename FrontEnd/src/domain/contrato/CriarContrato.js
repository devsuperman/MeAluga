import Locatario from "../locatario/Locatario";

export default class CriarContrato{
    
    constructor()
    {
        this.apartamentoId = '';              
        this.DataDeInicio = '';  
        this.duracao = 6;
        this.ValorDoAluguel = '';
        this.locatario = new Locatario();
    }

}