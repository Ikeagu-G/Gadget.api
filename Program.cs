using Microsoft.EntityFrameworkCore;
using Gadget.api.Data;
using Gadget.api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDBContext>(u => u.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddScoped<IGadgetRepo, GadgetRepo>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
AppDbInitializer.Configure(app);

//I later moved this out of program.cs to make the start up class slim. //DELETE ALL THIS AFTER YOU PULL

// Console.WriteLine("Attempting to apply migration----");
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     try{
//         var context = services.GetRequiredService<AppDBContext>();
//         context.Database.EnsureCreated();
//         AppDbInitializer.SeedData(context);

//     }
//     catch(Exception ex)
//     {

//         var log = services.GetRequiredService<ILogger<Program>>();
//         log.LogError(ex,"Error while attempting DB migrations.");
//     }
// }


//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();







