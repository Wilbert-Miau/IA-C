using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Web_MVC_IA_CAST.Models
{
    public class podcastEpisodeModel
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public int EpisodeNumber { get; set; }
        public List<guestModel>? Guests { get; set; }

        public string? Theme { get; set; }

        
        
        public List<hostModel>? Hosts { get; set; }

        [DataType(DataType.Date)]

        public DateTime DateRelease { get; set; }


   
      
       
    }
}
