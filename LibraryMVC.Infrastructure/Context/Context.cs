using LibraryMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BorrowerContactInformation> BorrowerContactInformations { get; set; }
        public DbSet<Item> Items { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }
        /*
 protected override void OnModelCreating(ModelBuilder builder)
 {



     builder.Entity<Item>()
         .HasNoKey();


 }



 builder.Entity<ItemTag>()
     .HasOne<Item>(it => it.Item)
     .WithMany(i => i.ItemTags)
     .HasForeignKey(it => it.ItemId);

 builder.Entity<ItemTag>()
     .HasOne<Tag>(it => it.Tag)
     .WithMany(t => t.ItemTags)
     .HasForeignKey(it => it.TagId);
 */
    }

}

