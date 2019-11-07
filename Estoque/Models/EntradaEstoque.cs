using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models
{
    [Table("Italo_EntradaEstoque")]
    public class EntradaEstoque : BaseEntity
    {
        public virtual Material Material { get; set; }

        [Column("MaterialID")]
        public int MaterialID { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }
    }
}
