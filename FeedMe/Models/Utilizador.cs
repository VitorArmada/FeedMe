using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models {
	public class Utilizador
	{
		public static int NORMAL = 0;
		public static int ADMIN = 1;

        public int UtilizadorId { get; set; }
        [Required][Unique]
        public string Nome { get; set; }
        [Required]
        public int Tipo { get; set; }

        public virtual ICollection<Receita> Receitas { get; set; }
        public virtual ICollection<Classificacao> Classificacoes { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Ingrediente> Ingredientes { get; set; }

		public bool isAdmin ()
		{
			return this.Tipo == 1;
		}
    }
}