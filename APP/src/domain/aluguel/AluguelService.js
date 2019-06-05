export default class AluguelService{

    constructor(resource)
    {
        this.Resource = resource('alugueis{/id}');   
    }
        
    pagar(model)
    {
        return this.Resource.update({id: model.id}, model);
    }

}