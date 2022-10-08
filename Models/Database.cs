using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using McDonalds.Models;

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
      options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
  }
}