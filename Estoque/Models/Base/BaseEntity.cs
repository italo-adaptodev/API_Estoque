using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Estoque.Models
{
	public class BaseEntity
	{
		[Column("Id")]
        public int Id { get; set; }
	}
}
