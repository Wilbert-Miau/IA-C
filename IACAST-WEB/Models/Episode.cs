
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace IACAST_WEB.Models
{
    public class Episode
    {

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(45, MinimumLength = 3)]
         public string? Name { get; set; }

        [Display(Name = "Tema")]
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string? Theme { get; set; }

        
        public string? Invitado { get; set; }
        
        public string? Anfitrion { get; set; }


        [DataType(DataType.Date)]
        public DateTime Released { get; set; }
        
        [RegularExpression(@"^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$")]
        public string? Youtube { get; set; }
    }
}
