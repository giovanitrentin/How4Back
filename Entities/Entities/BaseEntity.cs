using System;

namespace Entities.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? UsuarioCriacao { get; set; }
        public int? UsuarioAlteracao { get; set; }
        public bool? IsAtivo { get; set; }
    }
}

