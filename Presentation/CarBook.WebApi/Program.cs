using CarBook.Application.Interfaces;
using CarBook.Application.Mapping;
using CarBook.Application.Services;
using CarBook.Persistance.Context;
using CarBook.Persistance.Repositories;
using CarBook.WebApi.Controllers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CarbookContext>();
builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
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
