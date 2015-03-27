using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models
{
    public class Receita
    {
        public int ReceitaId { get; set; }
		[Required(ErrorMessage = "A receita precisa de um título.")]
        public string Titulo { get; set; }
		[DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
		[Required(ErrorMessage = "Quantos minutos demora a receita?"), Range( 0, 1440, ErrorMessage = "Escolha um tempo válido." )]
		public int Duracao { get; set; }
		public int? CustoId { get; set; }
		public virtual Custo Custo { get; set; }
		public int? DificuldadeId { get; set; }
		public virtual Dificuldade Dificuldade { get; set; }
		[RegularExpression(@"[0-9]+(-[0-9]+)?", ErrorMessage = "Indique o número de pessoas no seguinte formato, por ex: \"4-6\" ou \"10\" (sem aspas).")]
        public string NumeroPessoas { get; set; }

		[Required(ErrorMessage = "Escolha um tipo para a receita.")]
		public int TipoId { get; set; }
		public virtual Tipo Tipo { get; set; }

		public int? UtilizadorId { get; set; }
		public virtual Utilizador Utilizador { get; set; }

		public int? OrigemId { get; set; }
		public virtual Origem Origem { get; set; }

		public virtual ICollection<IngredienteReceita> IngredientesReceita { get; set; }
        public virtual ICollection<Classificacao> Classificacoes { get; set; }
		public virtual ICollection<Etapa> Etapas { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }

		public String getLastPictureUrl ()
		{
			var rr =
				from x in this.Etapas
				where String.IsNullOrWhiteSpace(x.Imagem) == false
				select x;
			if ( rr.Count() == 0 )
				return "~/Content/img/noimg.png";
			else
				return rr.Last().Imagem;
		}

		public int averageClassificacao ()
		{
			int sum = 0;
			int count = Classificacoes.Count();

			if ( count == 0 ) return 0;

			foreach ( var item in Classificacoes )
			{
				sum += item.Valor;
			}
			return sum / count;
		}

		public int totalComentarios ()
		{
			return Comentarios.Count();
		}
    }


}