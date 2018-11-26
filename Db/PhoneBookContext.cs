using Microsoft.EntityFrameworkCore;

namespace Db
{
	public class PhoneBookContext : DbContext
	{
		public DbSet<PhoneBookEntity> PhoneBookEntities { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
					"Server=10.11.21.12;Database=SampleDb;Trusted_Connection=True;",
					sqlConfig => sqlConfig.MigrationsHistoryTable("__MigrationHistory"));
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PhoneBookEntity>();
		}
	}
}
