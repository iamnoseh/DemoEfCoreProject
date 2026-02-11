using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Profiles;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDataContext>(option => 
    option.UseNpgsql("Server=localhost;Port=5432;Database=lesson_2;UserName=postgres;Password=12345;"));

builder.Services.AddScoped<IUserService,UserService>(op =>
    new UserService(
        op.GetRequiredService<ApplicationDataContext>(),
        op.GetRequiredService<IMapper>() 
    ));
builder.Services.AddScoped<ICountryService, CountryService>();

//AitoMapper
builder.Services.AddAutoMapper(typeof(MapProfile));
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();