using Microsoft.EntityFrameworkCore;
using StudentsAPI.Data;
using System.Text.Json.Serialization;

namespace StudentsAPI
{
	
	public class Startup
	{
		static void Main(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<StudentsAPIContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


			builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			using (var scope = app.Services.CreateScope()) { var services = scope.ServiceProvider; SeedData.Initialize(services); }
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}

}
