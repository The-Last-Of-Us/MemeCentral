namespace MemeCentral.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	using Common;

	public class Meme
	{
		private ICollection<Comment> comments;

		public Meme()
		{
			this.comments = new HashSet<Comment>();
		}

		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		public virtual User User { get; set; }

		[Required]
		[MinLength(ValidationConstants.MemeTitleMinLength)]
		[MaxLength(ValidationConstants.MemeTitleMaxLength)]
		public string Title { get; set; }

		[Required]
		[MaxLength(ValidationConstants.MemeImageUrlMaxLength)]
		public string ImageUrl { get; set; }

		public int Likes { get; set; }

		public int Dislikes { get; set; }

		public DateTime CreationDate { get; set; }

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
	}
}