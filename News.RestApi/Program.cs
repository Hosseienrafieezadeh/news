using Microsoft.EntityFrameworkCore;
using News.Contracts.Interface;
using News.persistence.EF;

using News.Persistence.EF.News;
using News.Services.News;
using News.Services.News.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFDataContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<NewsService, NewsAppService>();
builder.Services.AddScoped<NewsRepozitory,EFNewsRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
