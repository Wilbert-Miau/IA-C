using System.ComponentModel.DataAnnotations;

namespace IACAST_WEB.Models
{
    public class Post
    {
        public int Id { get; set; }


        [Required]
        [StringLength(65, MinimumLength = 3)]
        public string? Title { get; set; }

        [StringLength(200, MinimumLength = 3)]
       
        public string? Description { get; set; }
        [StringLength(65, MinimumLength = 3)]
        public string? Author { get; set; }

        [Required]
        public string? Content { get; set; }
        [StringLength(65, MinimumLength = 3)]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }
  

    }
    
}
