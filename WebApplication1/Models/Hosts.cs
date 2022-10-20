namespace WebApplication1.Models
{
    public class Hosts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Hosts(int id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}
