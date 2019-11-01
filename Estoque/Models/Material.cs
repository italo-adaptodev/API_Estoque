using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
