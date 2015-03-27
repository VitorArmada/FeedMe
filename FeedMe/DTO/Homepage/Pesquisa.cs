using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedMe.DTO.Homepage
{
    public class Pesquisa
	{
		public string titulo { get; set; }
		public string descricao { get; set; }
		public string tipo { get; set; }
		public string origem { get; set; }
		public string dificuldade { get; set; }
		public string custo { get; set; }
		public IList<Ingrediente> ingrSim { get; set; }
		public IList<Ingrediente> ingrNao { get; set; }
		public int ignoreOptions { get; set; }
    }
}