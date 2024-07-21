using Ocelot.Middleware;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddMvc();


var app = builder.Build();

app.UseRouting();

app.UseOcelot().Wait();

app.Run();