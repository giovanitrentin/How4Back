namespace Entities.Entities
{
    public class Endereco : BaseEntity
    {
        public string Rua {get;set;}
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade {get;set;}
        public string Estado {get;set;}
        public string Pais { get; set; }
    }
}
