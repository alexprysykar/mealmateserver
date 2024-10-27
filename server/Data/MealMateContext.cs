using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class MealMateContext : DbContext
    {
        public MealMateContext(DbContextOptions<MealMateContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}