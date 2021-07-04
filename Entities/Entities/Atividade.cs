using System;

namespace Entities.Entities
{
    public class Atividade : BaseEntity
    {
        public int? IdCliente { get; set; }
        public int? IdContatoCliente { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdStatus { get; set; }
        public int? IdTipoContato { get; set; }
        public DateTime? DataContato { get; set; }
        public string DescricaoContato { get; set; }
        public DateTime? DataRetorno { get; set; }
        public DateTime? DataProximoContato { get; set; }
        public bool? IsContatoFinalizado { get; set; }
    }
}
