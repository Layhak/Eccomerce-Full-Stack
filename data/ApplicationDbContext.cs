using Eccomerce_Full_Stack.Models;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce_Full_Stack.data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category>  Category { get; set; }
    public DbSet<Product> Product { get; set; }

}