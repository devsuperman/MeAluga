export default class Locatario{
     
    constructor(nome = '', cpf = '', rg = '', nacionalidade = '', profissao = '', estadoCivil = '')
    {
        this.nome = nome;
        this.cpf = cpf;
        this.rg = rg;
        this.nacionalidade = nacionalidade;
        this.profissao = profissao,
        this.estadoCivil = estadoCivil;
    }    
    
}