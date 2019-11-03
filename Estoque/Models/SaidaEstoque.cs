using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Models
{
    public class SaidaEstoque
    {
        [Column("data")]
        public DateTime Data { get; set; }

        [Column("MaterialID")]
        public virtual Material MaterialID { get; set; }

        [Column("quantidade")]
        public double Quantidade { get; set; }
    }
}
