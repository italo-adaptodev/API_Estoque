using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models
{
    public class Material : BaseEntity
    {
        [Column("TipoMaterialID")]
        public virtual TipoMaterial TipoMaterialID { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

    }
}
