using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess;

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        ///////////Rol////////////
        _modelBuilder.Entity<Role>(p =>
        {
            p.HasData(
                new Role
                {
                    Id = 1,
                    Name = "Administrador",
                    Description = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "Standard",
                    Description = "Usuario con algunos permisos de escritura"
                },
                new Role
                {
                    Id = 3,
                    Name = "Invitado",
                    Description = "Solo permisos de lectura"
                }
            );
        });

        ///////////Usuarios////////////
        _modelBuilder.Entity<User>(p =>
        {
            p.HasData(
                new User
                {
                    Id = 1,
                    First_name = "Clint",
                    Last_name = "Eastwood",
                    Email = "clint@eastwood.com",
                    Password = "Clint",
                    Points = 30,
                    Rol_id = 2
                },
                new User
                {
                    Id = 2,
                    First_name = "Arnold",
                    Last_name = "Schwarzenegger",
                    Email = "arnoldsg@skynet.com",
                    Password = "Arnold",
                    Points = 2000,
                    Rol_id = 1
                },
                new User
                {
                    Id = 3,
                    First_name = "Sylvester",
                    Last_name = "Stallone",
                    Email = "sylvesters@hollywood.com",
                    Password = "Sylvester",
                    Points = 2000,
                    Rol_id = 3
                }
            );
        });

        ///////////Accounts////////////
        _modelBuilder.Entity<Account>(p =>
        {
            p.HasData(
                new Account
                {
                    Id = 1,
                    CreationDate = new DateTime(1995, 11, 19),
                    Money = 150000,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 2,
                    CreationDate = new DateTime(2021, 12, 19),
                    Money = 50,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 3,
                    CreationDate = new DateTime(1999, 02, 05),
                    Money = 5000,
                    IsBlocked = false,
                    User_id = 1
                }, new Account
                {
                    Id = 4,
                    CreationDate = new DateTime(2010, 04, 10),
                    Money = 10034,
                    IsBlocked = false,
                    User_id = 2
                },
                new Account
                {
                    Id = 5,
                    CreationDate = new DateTime(2018, 01, 10),
                    Money = 4887,
                    IsBlocked = true,
                    User_id = 2
                },
                new Account
                {
                    Id = 6,
                    CreationDate = new DateTime(2001, 05, 03),
                    Money = 25040,
                    IsBlocked = false,
                    User_id = 2
                }
            );
        });

        ///////////Transaction(transferencias)////////////
        _modelBuilder.Entity<Transaction>(p =>
        {
            p.HasData(
                new Transaction
                {
                    Transaction_id = 1,
                    Amount = 15155,
                    Concept = "crédito",
                    Date = new DateTime(2020, 01, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 2
                },
                new Transaction
                {
                    Transaction_id = 2,
                    Amount = 4922,
                    Concept = "Efectivo",
                    Date = new DateTime(1999, 04, 14),
                    Type = "Debito",
                    Account_id = 2,
                    User_id = 2
                },

                new Transaction
                {
                    Transaction_id = 3,
                    Amount = 9340,
                    Concept = "Prestamo",
                    Date = new DateTime(2002, 03, 04),
                    Type = "crédito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 4,
                    Amount = 3211,
                    Concept = "Sueldo",
                    Date = new DateTime(2013, 05, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 5,
                    Amount = 55552,
                    Concept = "crédito",
                    Date = new DateTime(2022, 02, 18),
                    Type = "Efectivo",
                    Account_id = 2,
                    User_id = 2
                },
                new Transaction
                {
                    Transaction_id = 6,
                    Amount = 224,
                    Concept = "Reintegro",
                    Date = new DateTime(1980, 08, 12),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 2
                },
                new Transaction
                {
                    Transaction_id = 7,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1990, 11, 22),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                }
            );
        });

        ///////////FixedTermDeposit(plazo fijo etc.)////////////
        _modelBuilder.Entity<FixedTermDeposit>(p =>
        {
            p.HasData(
                new FixedTermDeposit
                {
                    Id = 1,
                    User_id = 1,
                    Account_id = 1,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 2,
                    User_id = 1,
                    Account_id = 2,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 3,
                    User_id = 2,
                    Account_id = 4,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 4,
                    User_id = 2,
                    Account_id = 5,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                }
            );
        });

        ///////////Catalogue(catalogo de productos?,puede ser prestamo personal a tienda de electrodomesticos tmb, hay que consultar.)////////////

        _modelBuilder.Entity<Catalogue>(p =>
        {
            p.HasData(
                new Catalogue
                {
                    Id = 1,
                    Product_description = "cocina",
                    Image = "",
                    Points = 300
                },
                new Catalogue
                {
                    Id = 2,
                    Product_description = "Lavarropas",
                    Image = "",
                    Points = 500
                },
                new Catalogue
                {
                    Id = 3,
                    Product_description = "Heladera",
                    Image = "",
                    Points = 700
                },
                new Catalogue
                {
                    Id = 4,
                    Product_description = "Lavavajillas",
                    Image = "",
                    Points = 400
                },
                new Catalogue
                {
                    Id = 5,
                    Product_description = "Freezer",
                    Image = "",
                    Points = 600
                },
                new Catalogue
                {
                    Id = 6,
                    Product_description = "Microondas",
                    Image = "",
                    Points = 200
                },
                new Catalogue
                {
                    Id = 7,
                    Product_description = "Horno Electrico",
                    Image = "",
                    Points = 400
                },
                new Catalogue
                {
                    Id = 8,
                    Product_description = "Horno Grande",
                    Image = "",
                    Points = 500
                },
                new Catalogue
                {
                    Id = 9,
                    Product_description = "Panificadora",
                    Image = "",
                    Points = 200
                },
                new Catalogue
                {
                    Id = 10,
                    Product_description = "Cepillo Electrico",
                    Image = "",
                    Points = 100
                }
            );
        });
    }
}