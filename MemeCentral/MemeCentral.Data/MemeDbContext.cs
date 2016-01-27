namespace MemeCentral.Data
{
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;
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

		public virtual IDbSet<Like> Likes { get; set; }

		public static MemeDbContext Create()
		{
			return new MemeDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
            // TODO: Bad fix for "cycles or multiple cascade paths" error, fix with something like:
            modelBuilder.Entity<Meme>().HasRequired(x => x.User).WithMany().WillCascadeOnDelete();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();
            base.OnModelCreating(modelBuilder);
		}
	}
}