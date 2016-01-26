namespace MemeCentral.Data.Migrations
{
	using System;
	using System.Linq;
	using System.Data.Entity.Migrations;

	using Models;

    public sealed class Configuration : DbMigrationsConfiguration<MemeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

		protected override void Seed(MemeDbContext db)
		{
			User[] users = new User[2];
			for (int i = 0; i < users.Length; i++)
			{
				users[i] = new User
				{
					UserName = $"SeedUser[{i}]",
					Email = $"SeedUser[{i}]@seed.com",
					PasswordHash = $"such hash this is not [{i}]"
				};
			}

			string username = users[0].UserName;
			if (db.Users.Any(user => user.UserName == username))
			{
				return;
			}

			Meme[] memes = new Meme[1];
			for (int i = 0; i < memes.Length; i++)
			{
				memes[i] = new Meme
				{
					UserId = users[0].Id,
					User = users[0],
					Title = $"SeedMeme[{i}]",
					ImageUrl = "http://static1.squarespace.com/static/55674e06e4b0830d6f6d4322/55ad1b7ce4b0218e8e379b4b/55ad1b7de4b0218e8e379b4c/1437408203254/Seed-germinating.jpg",
					Likes = (i + 7) * ((int)Math.Sin(17 * i)),
					Dislikes = (i + 2) * ((int)Math.Cos(13 * i)),
				};
			}

			Comment[] comments = new Comment[3];
			for (int i = 0; i < comments.Length; i++)
			{
				comments[i] = new Comment
				{
					UserId = users[1].Id,
					User = users[1],
					Meme = memes[0],
					Content = $"The meme is a seed... [{i}]"
				};
			}

			db.Users.AddOrUpdate(u => u.UserName, users);

			db.Memes.AddOrUpdate(m => m.Title, memes);

			db.Comments.AddOrUpdate(c => c.Content, comments);
		}
	}
}