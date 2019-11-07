using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models
{
    [Table("Italo_SaidaEstoque")]
    public class SaidaEstoque : BaseEntity
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
