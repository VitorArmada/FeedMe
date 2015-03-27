using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeedMe.Models;

namespace FeedMe.Controllers
{
    public class IngredienteController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

		#region API

		[HttpPost]
		public ActionResult APICreate ( String nome )
		{
			String response;
			try
			{
				Ingrediente i = new Ingrediente { Nome = nome };
				response = "O ingrediente \"" + i.Nome + "\" foi adicionado.";
				db.Ingredientes.Add(i);
				db.SaveChanges();
			} catch
			{
				HttpContext.Response.StatusCode = 500;
				response = "O ingrediente já existe.";
			}
			return Content(response);
		}

		[HttpPost]
		public ActionResult APIModify ( int id, String nome )
		{
			String response;
			try
			{
				Ingrediente i = db.Ingredientes.Find(id);
				response = "O ingrediente \"" + i.Nome + "\" foi renomeado para \"" + nome + "\".";
				i.Nome = nome;
				db.Entry(i).State = EntityState.Modified;
				db.SaveChanges();
			} catch
			{
				HttpContext.Response.StatusCode = 500;
				response = "Já existe um ingrediente com esse nome.";
			}
			return Content(response);
		}

		[HttpPost]
		public ActionResult APIRemove ( int id )
		{
			String response;
			try
			{
				Ingrediente i = db.Ingredientes.Find(id);
				response = "O ingrediente \"" + i.Nome + "\" foi removido.";
				db.Ingredientes.Remove(i);
				db.SaveChanges();
				//Json(new { text = response });
			} catch
			{
				HttpContext.Response.StatusCode = 500;
				response = "Houve um problema ao remover o ingrediente.";
			}
			return Content(response);
		}

		[HttpPost]
		public ActionResult APIReplace ( int substituir, int substituto )
		{
			String response;

			//SUBSTITUI INGREDIENTES NA TABELA INGREDIENTES RECEITA
			var inds1 = from i in db.IngredientesReceita
						where i.IngredienteId == substituir
						select i;
			foreach ( IngredienteReceita ir in inds1 )
			{
				ir.IngredienteId = substituto;
			}

			//SUBSTITUI INGREDIENTE NOS INGREDIENTES QUE UTILIZADOR NAO QUER
			var us = from i in db.Utilizadores.Include(x => x.Ingredientes)
					 select i;
			foreach ( Utilizador u in us )
			{
				var ings = from i in u.Ingredientes
						   where i.IngredienteId == substituir
						   select i;
				foreach ( Ingrediente ir in ings )
				{
					ir.IngredienteId = substituto;
				}
			}
			
			Ingrediente Substituido = db.Ingredientes.Find(substituir);
			Ingrediente Substituto = db.Ingredientes.Find(substituto);

			response = "O ingrediente \"" + Substituido.Nome
				+ "\" foi substituido pelo ingrediente  \"" + Substituto.Nome + "\" .";
			db.Ingredientes.Remove(Substituido);
			db.SaveChanges();

			return Content(response);
		}


		/*
        private int PageSize = 10;
		       public ActionResult Search(string SearchParam)
        {
            var ingreds = from i in db.Ingredientes
                          where i.Nome.Contains(SearchParam)
                          orderby i.Nome
                          select i;

            return View(ingreds.ToList());
        }


        public ActionResult Index(int ? page)
        {
            var ingreds = from i in db.Ingredientes
                          orderby i.Nome
                           select i;
            int pageNumber = (page ?? 1);
            int totIngred = db.Ingredientes.Count();
            int totPages = (totIngred/PageSize);
            if (totIngred % PageSize != 0) totPages++;

            @ViewBag.totPages = totPages;
            @ViewBag.hasnextPage = (pageNumber + 1) <= totPages;
            @ViewBag.hasprevPage = (pageNumber - 1) >= 1;
            @ViewBag.currentPage = pageNumber;

            return View(ingreds.ToPagedList(pageNumber, PageSize));
        }
        
       
		*/


		
        public ActionResult Listar()
        {
            var ingreds = db.Ingredientes;
            return View(ingreds.ToList());
        }

        [HttpPost]
        public ActionResult FetchIngredientes(string searchTerm)
        {
            var json = from i in db.Ingredientes
                       where (i.Nome).Contains(searchTerm)
                       select new
                       {
                           id = i.IngredienteId,
                           text = i.Nome
                       };

            return Json(json.ToList().Take(5));
        }

		[HttpPost]
		public ActionResult APISetIngredientesUtilizador ( string nomeUser, IList<DTO.Homepage.Ingrediente> IngsList )
		{
			var user = ( from u in db.Utilizadores
						 where u.Nome == nomeUser
						 select u ).First();
			user.Ingredientes.Clear();
			if(IngsList != null)
			foreach( DTO.Homepage.Ingrediente item in IngsList )
			{
				var ing = db.Ingredientes.Find(item.id);
				user.Ingredientes.Add(ing);
				db.Entry(ing).State = EntityState.Modified;
			}
			db.Entry(user).State = EntityState.Modified;
			db.SaveChanges();
			return Content("Ingredientes configurados.");
		}

		[HttpPost]
		public ActionResult APIGetIngredientesUtilizador ( string nomeUser )
		{
			var user = ( from u in db.Utilizadores
						 where u.Nome == nomeUser
						 select u ).First();
			var ings = from i in user.Ingredientes
					   select new
					   {
						   id = i.IngredienteId,
						   text = i.Nome
					   };

			return Json(ings.ToList());
		}

		#endregion API

		//
        // GET: /Ingrediente/

        public ActionResult Index()
        {
            return View(db.Ingredientes.ToList());
        }

        //
        // GET: /Ingrediente/Details/5

        public ActionResult Details(int id = 0)
        {
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        //
        // GET: /Ingrediente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ingrediente/Create

        [HttpPost]
        public ActionResult Create(Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Ingredientes.Add(ingrediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingrediente);
        }

        //
        // GET: /Ingrediente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        //
        // POST: /Ingrediente/Edit/5

        [HttpPost]
        public ActionResult Edit(Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingrediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingrediente);
        }

        //
        // GET: /Ingrediente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        //
        // POST: /Ingrediente/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            db.Ingredientes.Remove(ingrediente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}