using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Models
{
    [Table("Italo_EntradaEstoque")]
    public class EntradaEstoque : BaseEntity
    {
        [Column("MaterialID")]
        public virtual Material MaterialID { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("quantidade")]
        public double Quantidade { get; set; }
    }
}
