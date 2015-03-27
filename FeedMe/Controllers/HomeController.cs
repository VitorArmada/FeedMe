using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeedMe.DTO;
using FeedMe.Models;
using FeedMe.Filters;

namespace FeedMe.Controllers {

	
    public class HomeController : Controller {

		private DatabaseContext db = new DatabaseContext();

		public ActionResult Index ()
		{

			var tipos = from i in db.Tipos
						select i.Nome;
			var origens = from i in db.Origens
						  select i.Nome;
			var dificuldades = from i in db.Dificuldades
						  select i.Nome;
			var custos = from i in db.Custos
						  select i.Nome;

			ViewBag.Tipos = new SelectList(tipos);
			ViewBag.Origens = new SelectList(origens);
			ViewBag.Dificuldades = new SelectList(dificuldades);
			ViewBag.Custos = new SelectList(custos);

			return View();
		}

		public ActionResult Error ( String Message, String ReturnUrl )
		{
			ViewBag.Message = Message;
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}

		[Authorize]
		public ActionResult Administracao ()
		{
			if ( db.isAdmin(User.Identity.Name) == false )
			{
				return RedirectToAction("Error", "Home",
					new { Message = "Apenas administradores são permitidos nesta secção." });
			}
			return View();
		}
    }
}
