namespace MemeCentral.Server
{
	using System.Linq;
	using System.Data.Entity;

	using Data;
	using Data.Models;
	using Data.Migrations;

	public static class DataConfig
	{
		public static void Init()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<MemeDbContext, Configuration>());

			//using (var db = new MemeDbContext())
			//{
			//	db.Users.FirstOrDefault();
			//}
		}
	}
}