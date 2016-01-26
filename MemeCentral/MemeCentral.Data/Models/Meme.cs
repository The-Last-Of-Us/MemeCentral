namespace MemeCentral.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

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
		[MinLength(5)]
		[MaxLength(20)]
		public string Title { get; set; }

		[Required]
		[MaxLength(1000)]
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