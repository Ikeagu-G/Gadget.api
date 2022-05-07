using Gadget.api.Data;
using Gadget.api.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Gadget.api.Data
{

   public static class AppDbInitializer
   {
        public static void Configure(this IApplicationBuilder app)
        {
    
            Console.WriteLine("Attempting to apply migration----");
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;  //This line does the magic after several troubleshooting
                try
                {
                    var context = services.GetRequiredService<AppDBContext>();
                    //context.Database.EnsureCreated();  //Uncomment to do auto migrate with dotnet run. otherwise run add migration and Update db
                    AppDbInitializer.SeedData(context);

                }
                catch(Exception ex)
                {
                var log = services.GetRequiredService<ILogger<AppDBContext>>();
                log.LogError(ex,"Error while attempting DB migrations.");
                }
            }

        }


        private static void SeedData(AppDBContext context)
        {

            Console.WriteLine("Applying migration----");
            try
            {
                if (!context.Gadgets.Any())
                {
                    Console.WriteLine("---Seeding Data...");
                    context.Gadgets.AddRange(new Gadgets()
                    {
                        Name = "Tecno Pop 3",
                        Type = " Smartphone",
                        Brand = "Tecno",
                        CreatedDate = DateTime.Now,

                    },
                    new Gadgets()
                    {
                        Name = "Infinix Hot 10",
                        Type = " Smartphone",
                        Brand = "Infinix",
                        CreatedDate = DateTime.Now
                    });

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("---Already have Data");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--->Could not apply migration:{ex.Message}");
            }
            
        }
   }
    
}
