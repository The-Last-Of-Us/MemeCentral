namespace MemeCentral.Data.Models
{
	using System.Security.Claims;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

	// You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class User : IdentityUser
    {
		private ICollection<Meme> memes;

		private ICollection<Comment> comments;

		public User()
		{
			this.memes = new HashSet<Meme>();
			this.comments = new HashSet<Comment>();
		}

		public virtual ICollection<Meme> Memes
		{
			get
			{
				return this.memes;
			}

			set
			{
				this.memes = value;
			}
		}

		[InverseProperty("User")]
		public virtual ICollection<Comment> Comments
		{
			get
			{
				return this.comments;
			}

			set
			{
				this.comments = value;
			}
		}

		public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}