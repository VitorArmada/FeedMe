using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace FeedMe.Models {
    public class UsersContext : DbContext {
        public UsersContext()
            : base("DefaultConnection") {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel {
		[Required(ErrorMessage = "É obrigatório preencher o campo \"Nome de utilizador\".")]
		[Display(Name = "Nome de utilizador")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

	public class LocalPasswordModel
	{
		[Required(ErrorMessage = "É obrigatório preencher o campo \"Senha actual\".")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha actual")]
        public string OldPassword { get; set; }

		[Required(ErrorMessage = "É obrigatório preencher o campo \"Senha nova\".")]
        [StringLength(100, ErrorMessage = "A senha nova deve conter pelo menos {2} caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha nova")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
		[Display(Name = "Confirme a senha nova")]
		[Compare("NewPassword", ErrorMessage = "As duas senhas não são iguais.")]
        public string ConfirmPassword { get; set; }
    }

	public class LoginModel
	{
		[Required(ErrorMessage = "É obrigatório preencher o campo \"Nome de utilizador\".")]
        [Display(Name = "Nome de utilizador")]
        public string UserName { get; set; }

		[Required(ErrorMessage = "É obrigatório preencher o campo \"Senha\".")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-se de mim?")]
        public bool RememberMe { get; set; }
    }

	public class RegisterModel
	{
		[Required(ErrorMessage = "É obrigatório preencher o campo \"Nome de utilizador\".")]
		[Display(Name = "Nome de Utilizador")]
        public string UserName { get; set; }

		[Required(ErrorMessage = "É obrigatório preencher o campo \"Senha\".")]
		[StringLength(100, ErrorMessage = "A senha nova deve conter pelo menos {2} caracteres.", MinimumLength = 4)]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
        public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As duas senhas não são iguais.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
