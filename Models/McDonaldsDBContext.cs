using Microsoft.EntityFrameworkCore;

namespace McDonalds.Models
{
  public class McDonaldsDBContext : DbContext
  {
    protected readonly IConfiguration Configuration;

    public McDonaldsDBContext(DbContextOptions<McDonaldsDBContext> options, IConfiguration configuration) : base(options)
    {
      Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      var connectionString = Configuration.GetConnectionString("McDonaldsDataService");
      Console.WriteLine(connectionString);
      options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Food> Food { get; set; }
    public DbSet<Combo> Combo { get; set; }
    public DbSet<ComboItem> ComboItem { get; set; }

  }
}