using System;

namespace Entities.Entities
{
    public class ContatoCliente : BaseEntity
    {
        public int? IdCliente { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime? Aniversario { get; set; }
    }
}
