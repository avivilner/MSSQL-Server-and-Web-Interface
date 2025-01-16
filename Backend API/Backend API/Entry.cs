namespace Backend_API
{
	using System.ComponentModel.DataAnnotations;

	public class Entry
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[StringLength(100)]
		public string Term { get; set; }
	}
}