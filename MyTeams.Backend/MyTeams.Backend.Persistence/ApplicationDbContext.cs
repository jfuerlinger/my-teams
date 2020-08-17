using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyTeams.Backend.Core.Model;
using System;

namespace MyTeams.Backend.Persistence
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Team> Teams { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<ImageMessage> ImageMessages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(Environment.CurrentDirectory)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables();

      var configuration = builder.Build();
      string connectionString = configuration["ConnectionStrings:DefaultConnection"];
      optionsBuilder.UseSqlServer(connectionString);
    }
  }
}
