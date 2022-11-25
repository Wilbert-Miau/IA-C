using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IACAST_WEB.Models
{
    public class Post2
        
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

        public string? imagenName { get; set; }
        [NotMapped]
        [DisplayName("Subir imagen")]
        public IFormFile? Imagen { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }

    }
}
