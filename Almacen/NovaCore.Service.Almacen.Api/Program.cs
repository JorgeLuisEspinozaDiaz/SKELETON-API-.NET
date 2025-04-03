using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using NovaCore.Service.Almacen.Application;
using NovaCore.Service.Almacen.Infrastructure;


string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureServices(builder.Configuration);

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, 
                      builder => 
                      { 
                        builder.WithOrigins("*")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                     });
});

builder.Services.AddApplicationServices();
builder.Services.AddControllers();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ALMACEN.Api", Version = "v1" });
});

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ALMACEN.API v1"));

}
app.UseCors(MyAllowSpecificOrigins);
app.UseStaticFiles();

app.MapControllers(); // <- Esto se asegura de mapear los controladores correctamente

// app.UseHttpsRedirection();
  

app.Run();
 