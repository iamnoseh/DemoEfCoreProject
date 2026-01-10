using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDataContext>(option=> 
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<ApplicationDataContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICountryService, CountryService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();