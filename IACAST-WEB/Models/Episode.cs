using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace IACAST_WEB.Models
{
    public class Episode
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Theme { get; set; }

        
        public string? Invitado { get; set; }
        public string? Anfitrion { get; set; }

     

        [DataType(DataType.Date)]
        public DateTime? Released { get; set; }
    }
}
