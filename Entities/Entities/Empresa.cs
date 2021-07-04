namespace Entities.Entities
{
    public class Empresa : BaseEntity
    {
        public string RazaoSocial { get; set; }
        public int? IdEndereco { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
    }
}
