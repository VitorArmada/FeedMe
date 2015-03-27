using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeedMe.Models;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using System.Web.Security;
using DotNetOpenAuth.AspNet;

namespace FeedMe.Controllers
{
    public class UtilizadoresController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        //
        // GET: /Utilizadores/

        public ActionResult Index()
        {
            return View(db.Utilizadores.ToList());
        }

        //
        // GET: /Utilizadores/Details/5

        public ActionResult Details(int id = 0)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        //
        // GET: /Utilizadores/Delete/5

		[Authorize]
        public ActionResult Delete(int id = 0)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        //
        // POST: /Utilizadores/Delete/5

		[Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
		{
			if ( db.isAdmin(User.Identity.Name) == false )
			{
				return RedirectToAction("Error", "Home",
					new { Message = "Para eliminar contas de utilizadores é necessário ser administrador." });
			}
            Utilizador utilizador = db.Utilizadores.Find(id);

			var receitas =
				from r in db.Receitas
				where r.UtilizadorId == utilizador.UtilizadorId
				select r;

			foreach( Receita r in receitas )
			{
				r.UtilizadorId = null;
				db.Entry(r).State = EntityState.Modified;
			}

            db.Utilizadores.Remove(utilizador);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }


		[HttpPost]
		public ActionResult APIRemove ( int id )
		{
			String response;
			try
			{
				Utilizador utilizador = db.Utilizadores.Find(id);
				response = "A conta do utilizador \"" + utilizador.Nome + "\" foi eliminada.";
				( (SimpleMembershipProvider) Membership.Provider ).DeleteAccount(utilizador.Nome);
				( (SimpleMembershipProvider) Membership.Provider ).DeleteUser(utilizador.Nome, true);

				var receitas =
					from r in db.Receitas
					where r.UtilizadorId == utilizador.UtilizadorId
					select r;

				foreach ( Receita r in receitas )
				{
					r.UtilizadorId = null;
					db.Entry(r).State = EntityState.Modified;
				}

				db.Utilizadores.Remove(utilizador);
				db.SaveChanges();
				//Json(new { text = response });
			} catch
			{
				HttpContext.Response.StatusCode = 500;
				response = "Houve um problema ao eliminar a conta.";
			}
			return Content(response);
		}


		[HttpPost]
		public ActionResult APIGetUsers ( string searchTerm )
		{
			var json = from i in db.Utilizadores
					   where ( i.Nome ).Contains(searchTerm)
					   select new
					   {
						   id = i.UtilizadorId,
						   text = i.Nome
					   };

			return Json(json.ToList().Take(5));
		}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}