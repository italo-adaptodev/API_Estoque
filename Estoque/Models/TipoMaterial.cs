using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models
{
    public class TipoMaterial : BaseEntity
    {
        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
