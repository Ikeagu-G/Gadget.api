using Gadget.api.Data;
using Gadget.api.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Gadget.api.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context=serviceScope.ServiceProvider.GetService<AppDBContext>();

                if (!context.Gadgets.Any())
                {
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
            }
        }
    }
}
