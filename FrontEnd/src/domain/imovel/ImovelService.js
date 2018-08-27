export default class ImovelService{

    constructor(resource)
    {
        this.Resource = resource('imoveis{/id}');   
    }

    listar()
    {
        return this.Resource.query()
            .then(res => res.json());
    }

    salvar(imovel)
    {
        if (imovel.id) {
            return this.Resource.update({id: imovel.id}, imovel);
        }
        else{            
            return this.Resource.save(imovel);
        }
    }

    apagar(id)
    {
        return this.Resource.delete({id});        
    }

    buscar(id)
    {
        return this.Resource.get({id})
        .then(res => res.json());
    }

}