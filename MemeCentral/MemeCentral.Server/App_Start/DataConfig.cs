namespace MemeCentral.Server
{
	using System.Data.Entity;

	using Data;
	using Data.Models;
	using Data.Migrations;

	public static class DataConfig
	{
		public static void Init()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<MemeDbContext, Configuration>());

			using (var db = new MemeDbContext())
			{
				db.Memes.Add(new Meme
				{
					Title = "Test Meme",
					ImageUrl = "www.testing.com",
					Likes = 5,
					Dislikes = 2
				});

				db.SaveChanges();
			}
		}
	}
}