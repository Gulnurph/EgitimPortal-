using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
	public class GetContentDto
	{
		public int Id { get; set; }
		public string? ContentType { get; set; } // İçerik türü (kitap, video, vb.)
		public string? ContentUrl { get; set; } // İçeriğin URL'si veya dosya yolu
		public int TrainingId { get; set; } // İlgili eğitimin Id'si
		public Training Training { get; set; } // İlgili eğitim
	}
}
