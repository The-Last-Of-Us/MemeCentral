namespace MemeCentral.Server
{
	using System;
	using System.Collections.Generic;
	using Microsoft.AspNet.Identity;

	using Common;
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
			const string HasEror = "has-error";

			bool memeValid = true;

			var titleFormGroupClasses = new HashSet<string>(this.TitleFormGroup.CssClass.Split(' '));

			var memeUrlFormGroupClasses = new HashSet<string>(this.MemeUrlFormGroup.CssClass.Split(' '));

			if (this.Title.Text.Length < ValidationConstants.MemeTitleMinLength || ValidationConstants.MemeTitleMaxLength < this.Title.Text.Length)
			{
				titleFormGroupClasses.Add(HasEror);
				memeValid = false;
			}
			else
			{
				titleFormGroupClasses.Remove(HasEror);
			}

			if (this.MemeUrl.Text == string.Empty || ValidationConstants.MemeImageUrlMaxLength < this.MemeUrl.Text.Length)
			{
				memeUrlFormGroupClasses.Add(HasEror);
				memeValid = false;
			}
			else
			{
				memeUrlFormGroupClasses.Remove(HasEror);
			}

			if (memeValid)
			{
				Meme meme = new Meme()
				{
					Title = this.Title.Text,
					ImageUrl = this.MemeUrl.Text,
					CreationDate = DateTime.Now,
					UserId = this.User.Identity.GetUserId()
				};

				this.dbContext.Memes.Add(meme);

				this.dbContext.SaveChanges();

				this.Response.Redirect("MemeDetails?id=" + meme.Id);
			}

			this.TitleFormGroup.CssClass = string.Join(" ", titleFormGroupClasses);
			this.MemeUrlFormGroup.CssClass = string.Join(" ", memeUrlFormGroupClasses);
		}
	}
}