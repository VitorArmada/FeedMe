using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models {
    public class Origem {
        public int OrigemId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Receita> Receitas { get; set; }
    }
}