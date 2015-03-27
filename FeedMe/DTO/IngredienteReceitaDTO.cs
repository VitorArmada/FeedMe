using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.DTO
{
	public class IngredienteReceitaDTO
	{
		[Required]
		public string Nome { get; set; }
		[Required]
		public string Quantidade { get; set; }
	}
}