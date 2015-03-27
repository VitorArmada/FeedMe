using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.DTO
{
    public class EtapaDTO
	{
		[Required(ErrorMessage = "Um passo precisa de um título.")]
		public string Titulo { get; set; }
		[Required(ErrorMessage = "Um passo precisa de uma descrição.")]
        public string Descricao { get; set; }
        public string NomeImagem { get; set; }
        public HttpPostedFileBase Imagem { get; set; }
    }
}
