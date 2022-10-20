using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace IACAST_WEB.Models
{
    public class Episode
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Theme { get; set; }

        [Display(Name ="Invitado")]
        public Guest? TheGuest { get; set; }

        [Display(Name = "Host")]
        public Hosts? TheHost { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Released { get; set; }
    }
}
