using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Models
{
    public class Episode
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Theme { get; set; }
        public Guest? TheGuest { get; set; }
        public Hosts? TheHost { get; set; }
        public DateTime? Released { get; set; }
    }
}
