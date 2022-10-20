namespace WebApplication1.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guest(int id, string name)
        {
            Id=id;
            Name = name;
        }
    }
}
