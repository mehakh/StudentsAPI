using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();
var app = builder.Build();
app.UseOcelot().Wait();
app.Run();
