using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models
{
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
