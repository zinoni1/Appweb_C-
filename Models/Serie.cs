using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppWeb1.Models
{
    public class Serie
    {
        public int Id { get; set; }
        [Display(Name = "Títol")]
        public string Title { get; set; }
        [Display(Name = "Data llançament")]
        [DataType(DataType.Date)]
        
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Gènere")]
        public string Genre { get; set; }
        [Display(Name = "Preu")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Display(Name = "Numero temporades")]
        public int num_temporades { get; set; }
    }
}
