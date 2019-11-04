using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
