using System.ComponentModel.DataAnnotations;

namespace WebApp.ModelViews
{
    public class ProductImg
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string discription { get; set; }

        public int price { get; set; }

        public IFormFile imageName { get; set; }
    }
}
