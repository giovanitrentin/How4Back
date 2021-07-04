using System;

namespace Entities.Entities
{
    public class Cliente : BaseEntity
    {
        public string RazaoSocial{ get; set; }
        public int? TipoDocumento{ get; set; }
        public string Documento{ get; set; }
        public int? IdEndereco { get; set; }
        public string Telefone { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public DateTime? Fundacao { get; set; }
    }
}
