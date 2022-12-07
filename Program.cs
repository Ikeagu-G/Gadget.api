using Microsoft.EntityFrameworkCore;
using Gadget.api.Data;
using Gadget.api.Repository;
using Gadget.api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDBContext>(u => u.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddScoped<IGadgetRepo, GadgetRepo>();
builder.Services.AddScoped<IGadgetUserRepo, GadgetUserRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Adding identity service
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                            .AddEntityFrameworkStores<AppDBContext>()
                                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(option =>
 {
     option.RequireHttpsMetadata = false;
     option.SaveToken = true;
     option.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = builder.Configuration["JwtSetting: Issuer"],
         ValidAudience = builder.Configuration["JwtSetting: Audience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSetting: Secretkey"])),
         ClockSkew = TimeSpan.Zero

     };
 });

//builder.Services.AddScoped<IHttpService, HttpService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
AppDbInitializer.ConfigureIdentity(app);


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







