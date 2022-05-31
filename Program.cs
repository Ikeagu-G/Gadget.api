using Microsoft.EntityFrameworkCore;
using Gadget.api.Data;
using Gadget.api.Repository;
using Gadget.api.Integration.Implementation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDBContext>(u => u.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddScoped<IGadgetRepo, GadgetRepo>();
//builder.Services.AddScoped<IHttpService, HttpService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
AppDbInitializer.Configure(app);


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







