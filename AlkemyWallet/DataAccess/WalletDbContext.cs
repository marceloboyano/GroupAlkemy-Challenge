using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlkemyWallet.Entities;

public class WalletDbContext : IdentityDbContext<ApplicationUser>
{
    public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<FixedTermDeposit> FixedTermDeposits { get; set; }
    public DbSet<Catalogue> Catalogues { get; set; }



    //en caso de usar CodeFirst a Sql
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        base.OnModelCreating(modelBuilder);
        foreach (var foreingKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreingKey.DeleteBehavior = DeleteBehavior.Restrict;
        }


        ///////////Rol////////////


        modelBuilder.Entity<Role>().HasData(
        new Role
        {
            Id = 1,
            Name = "vice presidente junior",
            Description = "Admin",

        });

        modelBuilder.Entity<Role>().HasData(
        new Role
        {
            Id = 2,
            Name = "usuario standard",
            Description = "usuario",

        });


        ///////////Usuarios////////////

        modelBuilder.Entity<User>().HasData(
        new User
        {
            Id = 1,
            First_name = "Clint",
            Last_name = "Eastwood",
            Email = "clint@eastwood.com ",
            Password = "Clint",
            Points = 30,
            Rol_id = 2
        });

        modelBuilder.Entity<User>().HasData(
         new User
         {
             Id = 2,
             First_name = "Arnold",
             Last_name = "Schwarzenegger",
             Email = "ArnoldSG@Skynet.com ",
             Password = "Arnold",
             Points = 2000,
             Rol_id = 1
         });
        ///////////Accounts////////////
        modelBuilder.Entity<Account>().HasData(
        new Account
        {
            Id = 1,
            CreationDate = new DateTime(1995, 11, 19),
            Money = 150000,
            IsBlocked = false,
            User_id = 1,
        });

        modelBuilder.Entity<Account>().HasData(
         new Account
         {
             Id = 2,
             CreationDate = new DateTime(1995, 11, 19),
             Money = 50,
             IsBlocked = true,
             User_id = 1,
         });

        ///////////Transaction(transferencias)////////////
        modelBuilder.Entity<Transaction>().HasData(
        new Transaction
        {
            Transaction_id = 1,
            Amount = 2000,
            Concept = "crédito",
            Date = new DateTime(2020, 01, 25),
            Type = "Efectivo",
            Account_id = 1,
            User_id = 2,

        });
        ///////////FixedTermDeposit(plazo fijo etc.)////////////
        modelBuilder.Entity<FixedTermDeposit>().HasData(
        new FixedTermDeposit
        {
            Id = 1,
            User_id = 1,
            Account_id = 1,
            Creation_date = new DateTime(2020, 01, 25),
            Amount = 23000,
            Closing_date = new DateTime(2021, 03, 22)


        });
        ///////////Catalogue(catalogo de productos?,puede ser prestamo personal a tienda de electrodomesticos tmb, hay que consultar.)////////////
        modelBuilder.Entity<Catalogue>().HasData(
        new Catalogue
        {
            Id = 1,
            Product_description = "cocina",
            Image = "",
            Points = 300,

        });
        modelBuilder.Entity<Catalogue>().HasData(
      new Catalogue
      {
          Id = 2,
          Product_description = "heladera",
          Image = "",
          Points = 1000,

      });
        modelBuilder.Entity<Catalogue>().HasData(
      new Catalogue
      {
          Id = 3,
          Product_description = "freezer",
          Image = "",
          Points = 500,

      });


        //en construccion
        ///////////////////////
        modelBuilder.Entity<Role>().ToTable("Role");
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Account>().ToTable("Account");
        modelBuilder.Entity<Transaction>().ToTable("Transaction");
        modelBuilder.Entity<FixedTermDeposit>().ToTable("FixedTermDeposit");
        modelBuilder.Entity<Catalogue>().ToTable("Catalogue");
        base.OnModelCreating(modelBuilder);

    }

}
