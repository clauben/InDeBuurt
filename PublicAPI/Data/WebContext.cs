using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Web.Data
{
	public class WebContext : DbContext
	{
		public WebContext(DbContextOptions<WebContext> options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Mention> Mentions { get; set; }
		public DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Comment>().ToTable("Comment");
			modelBuilder.Entity<Mention>().ToTable("Mention");
			modelBuilder.Entity<User>().ToTable("User");
		}
	}
}
