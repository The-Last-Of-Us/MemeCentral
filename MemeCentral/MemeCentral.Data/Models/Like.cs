namespace MemeCentral.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Like
	{
		[Key, Column(Order = 0)]
		public string UserId { get; set; }

		public virtual User User { get; set; }

		[Key, Column(Order = 1)]
		public int MemeId { get; set; }

		public virtual Meme Meme { get; set; }

		public bool Value { get; set; }
	}
}