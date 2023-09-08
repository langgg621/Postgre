using Microsoft.EntityFrameworkCore;
using WebApplication1.Enities;

namespace WebApplication1.AppDb
{
	public class MyDb: DbContext
	{
		public DbSet<Province> Provinces { get; set; }
		public DbSet<Ward> Wards { get; set; }
		public DbSet<District> Districts { get; set; }
		protected readonly IConfiguration _configuration;
		public MyDb(IConfiguration configuration) {
			_configuration = configuration;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseNpgsql(
				"Host=localhost;Port=5432;Database=DemoApi;Username=postgres;Password=342002;");
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<District>()
				.HasOne<Province>()
				.WithMany() 
				.HasForeignKey(d => d.ProvinceId);
			modelBuilder.Entity<Ward>()
				.HasOne<District>()
				.WithMany()
				.HasForeignKey(d => d.DistrictId);
		}
	}
}
