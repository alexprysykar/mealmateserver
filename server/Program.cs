using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Services;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(options =>
    {
        var odataBuilder = new ODataConventionModelBuilder();
        odataBuilder.EntitySet<Recipe>("Recipes");

        options.AddRouteComponents("api", odataBuilder.GetEdmModel())
               .Select()
               .Filter()
               .OrderBy()
               .Expand()
               .Count()
               .SetMaxTop(100);
    });

builder.Services.AddDbContext<MealMateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<RecipeService>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.Run();
