using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess
{
    

public class WalletDbContext : IdentityDbContext<ApplicationUser>
{
    public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
    {
    }

    public new DbSet<Role>? Roles { get; set; }
    public new DbSet<User>? Users { get; set; }
    public DbSet<Account>? Accounts { get; set; }
    public DbSet<Transaction>? Transactions { get; set; }
    public DbSet<FixedTermDeposit>? FixedTermDeposits { get; set; }
    public DbSet<Catalogue>? Catalogues { get; set; }



    //en caso de usar CodeFirst a Sql
    protected override void OnModelCreating(ModelBuilder builder)
    {


        base.OnModelCreating(builder);
        foreach (var foreingKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreingKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
        base.OnModelCreating(builder);
        new DbInitializer(builder).Seed();

        //en construccion
        ///////////////////////
        builder.Entity<Role>().ToTable("Role");
        builder.Entity<User>().ToTable("User");
        builder.Entity<Account>().ToTable("Account");
        builder.Entity<Transaction>().ToTable("Transaction");
        builder.Entity<FixedTermDeposit>().ToTable("FixedTermDeposit");
        builder.Entity<Catalogue>().ToTable("Catalogue");
        base.OnModelCreating(builder);

    }

}
}