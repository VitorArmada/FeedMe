using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models {
    public class Classificacao {
		[Key]
		public int ClassificacaoId { get; set; }
        [Required][Range(1,5)]
        public int Valor { get; set; }

        [Required]
        public int UtilizadorId { get; set; }
		public virtual Utilizador Utilizador { get; set; }
        [Required]
        public int ReceitaId { get; set; }
		public virtual Receita Receita { get; set; }
    }
}