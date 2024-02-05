using System.ComponentModel.DataAnnotations;

namespace AppWeb1.Models
{
    public class Plataforma
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public decimal Price_month { get; set; }

        public decimal Price_year { get; set; }

    }
}
