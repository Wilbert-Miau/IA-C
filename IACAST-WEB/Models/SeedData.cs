using IACAST_WEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace IACAST_WEB.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SQLiteContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SQLiteContext>>()))
            {
                // Look for any movies.
                if (context.Episode.Any())
                {
                    return;   // DB has been seeded
                }

                context.Episode.AddRange(
                    new Episode
                    {
                        Name = "Conversando con el senior dev Billy Fernandez",
                        Invitado = "Billy Fernandez",
                        Anfitrion = "Wilbert Castillo",
                        Released = DateAndTime.Now,
                        Theme= "web development",
                        Youtube ="www.youtube.com"

                    }


                ) ;
                context.SaveChanges();
            }
        }
    }
}
