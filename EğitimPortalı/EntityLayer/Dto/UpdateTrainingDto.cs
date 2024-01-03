using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
	public class UpdateTrainingDto
	{
        public int Id { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; } // Kategori (online, sınıf içi eğitim, kitap, sunum, makale, mini proje vb.)
        public string? Instructor { get; set; } // İç eğitmen/dış eğitmen
        public string? ImgUrl { get; set; }
        public int Quota { get; set; } // Kontenjan sayısı
        public decimal CostPerDay { get; set; } // Maliyeti (eğitim gün fiyatı)
        public string? Duration { get; set; } // Eğitim süresi
    }
}
