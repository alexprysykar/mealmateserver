using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MealMateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<RecipeService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.Run();
