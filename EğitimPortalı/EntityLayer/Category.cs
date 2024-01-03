using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Table("KATEGORI")]
   public class Category
    {
        [Key]
        public int CategoryID { get; set; } 
        public string? CategoryName { get; set; }
        public List<Training> Trainings { get; set; }
        //public Training Training { get; set;}

    }
}
