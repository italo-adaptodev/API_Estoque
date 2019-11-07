using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models
{
    [Table("Italo_Material")]
    public class Material : BaseEntity
    {
        [Column("TipoMaterialID")]
        public int TipoMaterialID { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        public virtual TipoMaterial TipoMaterial { get; set; }
    }
}
