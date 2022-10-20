using Microsoft.EntityFrameworkCore;
using Web_MVC_IA_CAST.Data;
namespace Web_MVC_IA_CAST.Models

{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Web_MVC_IA_CASTContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Web_MVC_IA_CASTContext>>()))
            {
                // Look for any movies.
                if (context.hostModel.Any())
                {
                    return;   // DB has been seeded
                }

                context.hostModel.AddRange(
                    new hostModel
                    {
                        Name = "Wilbert Castillo"
                    }
              


                );

                context.guestModel.AddRange(
                   new guestModel
                   {
                       Name = "Jorge Reyes"
                   },
                    new guestModel
                    {
                        Name = "Billy Fernandez"
                    },
                     new guestModel
                     {
                         Name = "Tania Pineda"
                     }



                   ) ;

                context.podcastEpisodeModel.AddRange(
                    new podcastEpisodeModel
                    {
                        Name="Conversando con el senior dev Billy Fernandez",
                    
                        EpisodeNumber=0,
                        DateRelease=DateTime.Now,
                        Theme="desarrollo web"
                    }
                    );

              
                context.SaveChanges();
            }
        }
    }
}
