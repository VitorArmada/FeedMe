using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models {
    public class IngredienteReceita {
        public int IngredienteReceitaId { get; set; }
        public string Quantidade { get; set; }

        [Required]
        public int ReceitaId { get; set; }
		public virtual Receita Receita { get; set; }
        [Required]
        public int IngredienteId { get; set; }
		public virtual Ingrediente Ingrediente { get; set; }
    }
}