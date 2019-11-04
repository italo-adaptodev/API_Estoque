using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models
{
    [Table("Italo_TipoMaterial")]
    public class TipoMaterial : BaseEntity
    {
        [Column("tipo")]
        public string tipo { get; set; }
    }
}
