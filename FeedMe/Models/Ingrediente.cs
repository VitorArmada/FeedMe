using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models {
    public class Ingrediente {
        public int IngredienteId { get; set; }
		[Required]
		[Unique(ErrorMessage = "Já existe um ingrediente com esse nome")]
        public string Nome { get; set; }

        public virtual ICollection<IngredienteReceita> IngredientesReceita { get; set; }
        public virtual ICollection<Utilizador> Utilizadores { get; set; }
    }
}