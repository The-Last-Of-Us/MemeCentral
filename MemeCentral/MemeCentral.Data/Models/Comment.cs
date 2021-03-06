namespace MemeCentral.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

	using Common;

    public class Comment
	{
		public int Id { get; set; }

		public int MemeId { get; set; }

		public virtual Meme Meme { get; set; }

		[Required]
		public string UserId { get; set; }

		public virtual User User { get; set; }

		[Required]
		[MaxLength(ValidationConstants.CommentMaxLength)]
		public string Content { get; set; }

        public DateTime CreationDate { get; set; }
	}
}