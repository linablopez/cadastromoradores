using Siscon_API_Backend;
using Siscon_API_Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationServices(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigurationServices(WebApplicationBuilder builder)
{
    var sisconConnectionString = builder.Configuration.GetConnectionString("SisconConnection");

    builder.Services.AddDbContext<SisconDataContext>(options => options.UseSqlServer(sisconConnectionString));

}