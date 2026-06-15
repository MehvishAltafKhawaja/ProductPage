using System.ComponentModel.DataAnnotations;

namespace WebApp.ModelViews
{
    public class UserImg
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public IFormFile ImageUrl { get; set; }
    }
}
