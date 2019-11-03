using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models
{
    public class BaseEntity
    {
        [Column("Id")]
        public int Id { get; set; }
    }
}
