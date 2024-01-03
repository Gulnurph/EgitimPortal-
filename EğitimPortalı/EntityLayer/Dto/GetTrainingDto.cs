using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
	public class GetTrainingDto
	{
		public int TrainigId { get; set; }
		public string? Title { get; set; }
		public int CategoryId { get; set; }
		
		public int InstructorId { get; set; } // Eğitmenin Id'si
	
		public int Capacity { get; set; }
		public decimal CostPerDay { get; set; }
		public int DurationInDays { get; set; }
	}
}
