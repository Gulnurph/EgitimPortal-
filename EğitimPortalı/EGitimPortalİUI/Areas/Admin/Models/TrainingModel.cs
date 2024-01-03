namespace EGitimPortaliUI.Areas.Admin.Models
{
    public class TrainingModel
    {
		public int Id { get; set; }
		public string? Title { get; set; }
		public int CategoryId { get; set; }// Kategori (online, sınıf içi eğitim, kitap, sunum, makale, mini proje vb.)
		public string? Instructor { get; set; } // İç eğitmen/dış eğitmen
		public int Quota { get; set; } // Kontenjan sayısı
		public decimal CostPerDay { get; set; } // Maliyeti (eğitim gün fiyatı)
		public string? Duration { get; set; } // Eğitim süresi
		public string? ImgUrl { get; set; }
	}
}
