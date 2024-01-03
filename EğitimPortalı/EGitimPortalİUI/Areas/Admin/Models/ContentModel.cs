namespace EGitimPortaliUI.Areas.Admin.Models
{
	public class ContentModel
	{
		public int Id { get; set; }
		public string? ContentType { get; set; } // İçerik türü (kitap, video, vb.)
		public string? ContentUrl { get; set; } // İçeriğin URL'si veya dosya yolu
		public int TrainingId { get; set; } // İlgili eğitimin Id'si
	}
}
