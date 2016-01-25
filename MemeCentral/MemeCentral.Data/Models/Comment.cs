namespace MemeCentral.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Comment
	{
		public int Id { get; set; }

		public int MemeId { get; set; }

		public virtual Meme Meme { get; set; }

		[Required]
		[MaxLength(200)]
		public string Content { get; set; }
	}
}