using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastruture.Data
{
	public class WebContext : DbContext
	{
		public WebContext(DbContextOptions<WebContext> options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		//public DbSet<UserDetail> UserDetails { get; set; }
		public DbSet<Mention> Mentions { get; set; }
		public DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Comment>().ToTable("Comment");
			modelBuilder.Entity<Mention>().ToTable("Mention");
			//modelBuilder.Entity<UserDetail>().ToTable("UserDetail");
			modelBuilder.Entity<User>().ToTable("User");
		}
	}
}
