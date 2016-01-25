namespace MemeCentral.Data
{
	using System.Data.Entity;
	using Microsoft.AspNet.Identity.EntityFramework;

	using Models;

	public class MemeDbContext : IdentityDbContext
	{
		public MemeDbContext()
			: base("MemeCentral")
		{
			;
		}

		public virtual IDbSet<Meme> Memes { get; set; }

		public virtual IDbSet<Comment> Comments { get; set; }


		public static MemeDbContext Create()
		{
			return new MemeDbContext();
		}
	}
}