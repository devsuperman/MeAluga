export default class EstadoCivilService{

    constructor(resource)
    {
        this.Resource = resource('estadosCivis{/id}');   
    }

    listar()
    {
        return this.Resource.query()
            .then(res => res.json());
    }
}