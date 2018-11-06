import Locatario from "../locatario/Locatario";

export default class Contrato{
    
    constructor()
    {
        this.id = '';        
        this.locatarioId = '';        
        this.imovelId = '';
        this.fiadorId = '';
        this.dataDeRegistro = '';  
        this.dataDeInicio = '';  
        this.dataDeTermino = '';  
        this.observacao = '';                
        this.locatario = new Locatario();        
        this.imovel = '';        
        this.fiador = '';    
        this.alugueis = [];
    }

    Situacao () {
        return 'Em Andamento';    //TODO: Resolver isso aqui
    }

}