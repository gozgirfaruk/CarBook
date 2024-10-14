using CarBook.Application.Interfaces;
using CarBook.Application.Mapping;
using CarBook.Application.Services;
using CarBook.Application.Tools;
using CarBook.Persistance.Context;
using CarBook.Persistance.Repositories;
using CarBook.WebApi.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
		{
			opt.RequireHttpsMetadata = false;
			opt.TokenValidationParameters = new TokenValidationParameters
			{
				ValidAudience = JwtTokenDefaults.ValidAudience,
				ValidIssuer = JwtTokenDefaults.ValidIssuer,
				ClockSkew = TimeSpan.Zero,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true
			};
		});
		// Add services to the container.

		builder.Services.AddDbContext<CarbookContext>();
		builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);

		//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
		builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		builder.Services.AddScoped<ICarRepository, CarRepository>();
		builder.Services.AddScoped<IBlogRepository, BlogRepository>();
		builder.Services.AddScoped<ICommentRepository, CommentRepository>();
		builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
		builder.Services.AddScoped<IRentACarRepository, RentACarRepository>();
		builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
		builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
		builder.Services.AddScoped<IReviewListByCarIdRepository, GetReviewListByCarIdRepository>();
		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		//services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
		builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();
		//app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}