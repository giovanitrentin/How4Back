using System;

namespace Entities.Entities
{
    public class Vendedor : BaseEntity
    {
        public int? IdEmpresa { get; set; }
        public DateTime? Nascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string TokenAccess { get; set; }
    }
}
