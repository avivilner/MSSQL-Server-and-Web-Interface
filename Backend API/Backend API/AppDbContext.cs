namespace Backend_API
{
	using Microsoft.EntityFrameworkCore;

	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Entry> Entries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Entry>()
				.ToTable("Terms")
				.HasIndex(t => t.Term)
				.IsUnique(); // Enforce unique constraint
		}
	}
}
