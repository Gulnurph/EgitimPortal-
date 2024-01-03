namespace EGitimPortaliUI.Models
{
    public class TrainingMd
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; } // Kategori (online, sınıf içi eğitim, kitap, sunum, makale, mini proje vb.)
        public string? Instructor { get; set; } // İç eğitmen/dış eğitmen
        public int Quota { get; set; } // Kontenjan sayısı
        public decimal CostPerDay { get; set; } // Maliyeti (eğitim gün fiyatı)
        public string? Duration { get; set; } // Eğitim süresi
        public string? ImgUrl { get; set; }
        public List<TrainingMd>  TrainingModels { get; set; }
    }
}
