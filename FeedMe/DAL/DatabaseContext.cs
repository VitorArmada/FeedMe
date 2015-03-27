using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FeedMe.DTO;

namespace FeedMe.Models
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext ()
		{
			//this.Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<Tipo> Tipos { get; set; }
		public DbSet<Origem> Origens { get; set; }
		public DbSet<Dificuldade> Dificuldades { get; set; }
		public DbSet<Custo> Custos { get; set; }
		public DbSet<Receita> Receitas { get; set; }
		public DbSet<Etapa> Etapas { get; set; }
		public DbSet<Ingrediente> Ingredientes { get; set; }
		public DbSet<IngredienteReceita> IngredientesReceita { get; set; }
		public DbSet<Utilizador> Utilizadores { get; set; }
		public DbSet<Comentario> Comentarios { get; set; }
		public DbSet<Classificacao> Classificacoes { get; set; }

		protected override void OnModelCreating ( DbModelBuilder modelBuilder )
		{
			modelBuilder.Entity<Utilizador>()
				.HasMany(u => u.Ingredientes)
				.WithMany(i => i.Utilizadores)
				.Map(t => t.MapLeftKey("UtilizadorId")
					.MapRightKey("Ingrediented")
					.ToTable("IngredientesUtilizador"));

			// Constraints ON DELETE CASCADE da Classificação

			modelBuilder.Entity<Classificacao>()
				.HasRequired(c => c.Utilizador)
				.WithMany(u => u.Classificacoes)
				.HasForeignKey(c => c.UtilizadorId)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Classificacao>()
				.HasRequired(c => c.Receita)
				 .WithMany(r => r.Classificacoes)
				 .HasForeignKey(c => c.ReceitaId)
				 .WillCascadeOnDelete(true);

			// Constraints ON DELETE CASCADE do Comentário

			modelBuilder.Entity<Comentario>()
				.HasRequired(c => c.Utilizador)
				.WithMany(u => u.Comentarios)
				.HasForeignKey(c => c.UtilizadorId)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Comentario>()
				.HasRequired(c => c.Receita)
				 .WithMany(r => r.Comentarios)
				 .HasForeignKey(c => c.ReceitaId)
				 .WillCascadeOnDelete(true);

			// Constraints ON DELETE CASCADE do IngredientesReceita

			modelBuilder.Entity<IngredienteReceita>()
				.HasRequired(ir => ir.Ingrediente)
				.WithMany(i => i.IngredientesReceita)
				.HasForeignKey(ir => ir.IngredienteId)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<IngredienteReceita>()
				.HasRequired(ir => ir.Receita)
				.WithMany(r => r.IngredientesReceita)
				.HasForeignKey(ir => ir.ReceitaId)
				.WillCascadeOnDelete(true);

			// Constraints ON DELETE CASCADE do Ingredientes

			modelBuilder.Entity<Etapa>()
				.HasRequired(e => e.Receita)
				.WithMany(r => r.Etapas)
				.HasForeignKey(e => e.ReceitaId)
				.WillCascadeOnDelete(true);

			// Constraints ON DELETE CASCADE das Receitas

			modelBuilder.Entity<Receita>()
				.HasRequired(r => r.Tipo)
				.WithMany(t => t.Receitas)
				.HasForeignKey(r => r.TipoId)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Receita>()
				.HasOptional(r => r.Origem)
				.WithMany(o => o.Receitas)
				.HasForeignKey(r => r.OrigemId)
				.WillCascadeOnDelete(true);
			
			modelBuilder.Entity<Receita>()
				.HasOptional(r => r.Utilizador)
				.WithMany(u => u.Receitas)
				.HasForeignKey(r => r.UtilizadorId)
				.WillCascadeOnDelete(false);
			
			modelBuilder.Entity<Receita>()
				.Property(r => r.UtilizadorId)
				.IsOptional();

			// Convenções

			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
		}


		//FeedMe.Models.DatabaseContext.getByName( User.Identity.Name )
		public static Utilizador getByName ( String user )
		{
			DatabaseContext db = new DatabaseContext();
			var us = (from x in db.Utilizadores where x.Nome == user select x).First();
			return us;
		}

		public static bool isAdminStatic ( String user )
		{
			DatabaseContext db = new DatabaseContext();
			var us = from x in db.Utilizadores where x.Nome == user select x;
			if ( us.Count() == 0 || us.First().isAdmin() == false )
			{
				return false;
			} else return true;
		}
		
		public bool isAdmin ( String user )
		{
			var us = from x in this.Utilizadores where x.Nome == user select x;
			if ( us.Count() == 0 || us.First().isAdmin() == false )
			{
				return false;
			} else return true;
		}

		public static bool isRecipeCreator ( String user, int RecipeId )
		{
			DatabaseContext db = new DatabaseContext();
			var rs = from x in db.Receitas where x.ReceitaId == RecipeId select x;
			if ( rs.Count() == 0 || rs.First().Utilizador.Nome != user ) return false;
			else return true;
		}

		public bool isCommentCreator ( String user, int CommentId )
		{
			var rs = from x in this.Comentarios where x.ComentarioId == CommentId select x;
			if ( rs.Count() == 0 || rs.First().Utilizador.Nome != user ) return false;
			else return true;
		}
	}
}