using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models {
    public class Etapa {
        public int EtapaId { get; set; }
        [Required]
        public int Numero { get; set; }
		[Required(ErrorMessage = "Um passo precisa de um título.")]
        public string Titulo { get; set; }
		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Um passo precisa de uma descrição.")]
        public string Descricao { get; set; }
        public string Imagem { get; set; } // TODO!

        [Required]
        public int ReceitaId { get; set; }
		public virtual Receita Receita { get; set; }
    }
}