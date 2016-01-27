namespace MemeCentral.Server
{
	using System;
	using Microsoft.AspNet.Identity;

	using Data.Models;

	public partial class AddMeme : BasePage
	{
		protected const string DefaultMemeUrl = "http://www.troll.me/images/yao-ming/insert-random-meme-here.jpg";

		protected void Page_Init()
		{
			this.MemeImg.ImageUrl = AddMeme.DefaultMemeUrl;
		}

		protected void UpdateMemeImg(object sender, EventArgs args)
		{
			if (this.MemeUrl.Text == string.Empty)
			{
				this.MemeImg.ImageUrl = AddMeme.DefaultMemeUrl;
			}
			else
			{
				this.MemeImg.ImageUrl = this.MemeUrl.Text;
			}
		}

		protected void CreateMeme(object sender, EventArgs args)
		{
			Meme meme = new Meme()
			{
				Title = this.Title.Text,
				ImageUrl = this.MemeUrl.Text,
				CreationDate = DateTime.Now,
				UserId = this.User.Identity.GetUserId()
			};
		}
	}
}