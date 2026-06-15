using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Product
    {
        [Key]
        public  int Id { get; set; } 
        public string name { get; set; }
        public string discription { get; set; }

        public int price { get; set; }

        public string imageName { get; set; }
    }
}
