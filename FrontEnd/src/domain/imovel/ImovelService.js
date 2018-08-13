export default class ImovelService{

    constructor(resource)
    {
        this.Resource = resource('imoveis{/id}');   
    }

    listar()
    {
        return this.Resource
            .query()
            .then(
                res => res.json(),
                err =>
                {
                    // eslint-disable-next-line
                    console.log(err);
                    throw new Error('Não foi possível listar.');
                }
            )
    }

    salvar(imovel)
    {
        if (imovel.Id) {
            return this.Resource.update({id: imovel.Id}, imovel)
                .then(
                    null,
                    err => {
                        // eslint-disable-next-line
                        console.log(err);
                        throw new Error('Não foi possível atualizar.');                        
                    }
                );
        }
        else{            
            return this.Resource.save(imovel)
                .then(
                    null,
                    err => {
                        // eslint-disable-next-line
                        console.log(err);
                        throw new Error('Não foi possível salvar.');                        
                    }
                );
        }
    }

    apagar(id)
    {
        return this.Resource.delete(id)
        .then(
            null,
            err => {
                // eslint-disable-next-line
                console.log(err);
                throw new Error('Não foi possível apagar.');                        
            }
        )
    }

    buscar(id)
    {
        return this.Resource.get({id})
        .then(
            res => res.json(),
            err => {
                // eslint-disable-next-line
                console.log(err);
                throw new Error('Não foi buscar.');                        
            }
        )
    }

}