using System.Security.Claims;
using Gadget.api.Data.Helper;
using Gadget.api.Data.Models;
using Gadget.api.ENUM;
using Microsoft.AspNetCore.Identity;

namespace Gadget.api.Data
{

   public static class AppDbInitializer
   {
        public static void ConfigureIdentity(this IApplicationBuilder app)
        {
    
            Console.WriteLine("Attempting to apply migration----");
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;  //This line does the magic after several troubleshooting
                try
                {
                    var context = services.GetRequiredService<AppDBContext>();
                    var userManager = services.GetService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetService<RoleManager<ApplicationRole>>();
                     //Uncomment to do auto migrate with dotnet run. otherwise run add migration and Update db
                    context.Database.EnsureCreated();
                    AppDbInitializer.SeedData(userManager, roleManager, context);
                    
                    

                }
                catch(Exception ex)
                {
                var log = services.GetRequiredService<ILogger<AppDBContext>>();
                log.LogError(ex,"Error while attempting DB migrations.");
                }
            }

        }


        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, AppDBContext context)
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

                    SeedRoles(roleManager);
                    SeedUsers(userManager);
                     //context.SaveChanges();
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


        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "SuperAdministrator",
                LastName = "Super",
                FirstName = "Super",
                MiddleName = "Admin",
                Status = Status.Active,
                Email = "SuperAdmin@gmail.com",
                EmailConfirmed = true,
                CreatedBy ="System",
                CreatedById = "::2",
                DateCreated = DateTime.Now,

            };

            IdentityResult result = userManager.CreateAsync(user, "PassWord2@").Result;
            if(result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "SuperAdmin");
            }
        }

        private static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if(!roleManager.RoleExistsAsync("SuperAdmin").Result)
            {
                ApplicationRole role = new ApplicationRole
                {
                    Name = "SuperAdmin",
                    Description = "To do administrative operation",
                    CreatedBy = "System",
                    Status = Status.Active,
                    DateCreated = DateTime.Now,
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                if(roleResult.Succeeded)
                {
                    var result = roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Access, "SuperAdmin")).Result;
                }
            }

        }


   }
    
}
