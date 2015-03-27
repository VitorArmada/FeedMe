using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedMe.DTO
{
    public class ComentarioDTO
    {
        public int userID { get; set; }
        public int receitaID { get; set; }
        public String texto { get; set; }
    }
}