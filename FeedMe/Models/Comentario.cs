using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models {
    public class Comentario {
        public int ComentarioId { get; set; }
        [Required]
        public string Texto { get; set; }
        [Required]
        public DateTime Data { get; set; }

        [Required]
        public int UtilizadorId { get; set; }
        public virtual Utilizador Utilizador { get; set; }
        [Required]
        public int ReceitaId { get; set; }
		public virtual Receita Receita { get; set; }
    }
}