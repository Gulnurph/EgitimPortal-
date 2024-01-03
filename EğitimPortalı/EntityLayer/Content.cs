using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
	[Table("CONTENT")]
	public class Content
	{
		[Key]
		public int Id { get; set; }
		public string? ContentType { get; set; } // İçerik türü (kitap, video, vb.)
		public string? ContentUrl { get; set; } // İçeriğin URL'si veya dosya yolu
		public int TrainingId { get; set; } // İlgili eğitimin Id'si
		public Training Training { get; set; } // İlgili eğitim
	}
}
