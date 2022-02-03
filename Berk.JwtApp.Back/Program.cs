using AutoMapper;
using Berk.JwtApp.Back.Core.Application.Interfaces;
using Berk.JwtApp.Back.Core.Application.Mappings;
using Berk.JwtApp.Back.Infrastructure.Tools;
using Berk.JwtApp.Back.Persistance.Context;
using Berk.JwtApp.Back.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JWTContext>(opt => {

    opt.UseSqlServer(builder.Configuration.GetConnectionString("local"));

});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());//mediatr i�in �al��t���n yeri gel ekle diyoruz.Zorunlu mediatr i�in
builder.Services.AddAutoMapper(opt => 
{
    opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile(),
        new CategoriesProfile()

    }) ;
    
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("GlobalCors", config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidAudience = JwtTokenSettings.Audience,
        ValidIssuer = JwtTokenSettings.Issuer,
        ClockSkew = TimeSpan.Zero,//serverla client aras�ndaki zaman farkl�l�klar� ile ilgili
        ValidateLifetime = true, //token�n s�resini do�rulas�n
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key)), //16 karakterden fazla olu�an bir �ey vermek zorunday�m.
        ValidateIssuerSigningKey = true,

};

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("GlobalCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
