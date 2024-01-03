using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
	[Table("TRAINING")]
	public class Training
	{
		[Key]
		public int Id { get; set; }
		public string? Title { get; set; }
		public int CategoryId { get; set; } // Kategori (online, sınıf içi eğitim, kitap, sunum, makale, mini proje vb.)
		public Category Categorys { get; set; }
		public string? Instructor { get; set; } // İç eğitmen/dış eğitmen
		public string? ImgUrl { get; set; }
		public int Quota { get; set; } // Kontenjan sayısı
		public decimal CostPerDay { get; set; } // Maliyeti (eğitim gün fiyatı)
		public string? Duration { get; set; } // Eğitim süresi
		public List<Content> Contents { get; set; } // Eğitim içerikleri
	}
}
