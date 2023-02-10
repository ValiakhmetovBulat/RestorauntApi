using Microsoft.EntityFrameworkCore;
using RestorauntApi.Models;
using System.Reflection;
using Microsoft.OpenApi.Models;
using RestorauntApi.Models.EntititesRepositories.Interfaces;
using RestorauntApi.Models.EntititesRepositories.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "Swagger Demo API",
            Description = "Demo API for showing Swagger work",
            Version = "v1"
        });
});

#region Repositories
builder.Services.AddTransient<IMenuPositionsRepository, MenuPositionsRepository>();
builder.Services.AddTransient<ISectionsRepository, SectionsRepository>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IPositionTypesRepository, PositionTypesRepository>();
#endregion

builder.Services.AddDbContext<RestorauntDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("RestorauntDb"))
    );

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }