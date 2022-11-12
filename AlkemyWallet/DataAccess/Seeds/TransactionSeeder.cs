using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds;

public class TransactionSeeder
{
    private readonly ModelBuilder _modelBuilder;

    public TransactionSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void SeedTransaction()
    {
        _modelBuilder.Entity<Transaction>(p =>
        {
            p.HasData(
                new Transaction
                {
                    Transaction_id = 1,
                    Amount = 15155,
                    Concept = "Crédito",
                    Date = new DateTime(2020, 01, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 2,
                    Amount = 4922,
                    Concept = "Efectivo",
                    Date = new DateTime(1999, 04, 14),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 3,
                    Amount = 9340,
                    Concept = "Prestamo",
                    Date = new DateTime(2002, 03, 04),
                    Type = "Crédito",
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
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 6,
                    Amount = 224,
                    Concept = "Reintegro",
                    Date = new DateTime(1980, 08, 12),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 7,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1994, 11, 11),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 8,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1990, 03, 20),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 9,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1990, 11, 22),
                    Type = "Credito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 10,
                    Amount = 202300,
                    Concept = "Sueldo",
                    Date = new DateTime(1990, 05, 18),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 11,
                    Amount = 15155,
                    Concept = "Crédito",
                    Date = new DateTime(2020, 01, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 12,
                    Amount = 4922,
                    Concept = "Efectivo",
                    Date = new DateTime(1999, 04, 14),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 13,
                    Amount = 9340,
                    Concept = "Prestamo",
                    Date = new DateTime(2002, 03, 04),
                    Type = "Crédito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 14,
                    Amount = 3211,
                    Concept = "Sueldo",
                    Date = new DateTime(2013, 05, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 15,
                    Amount = 55552,
                    Concept = "crédito",
                    Date = new DateTime(2022, 02, 18),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 16,
                    Amount = 224,
                    Concept = "Reintegro",
                    Date = new DateTime(1980, 08, 12),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 17,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1990, 06, 22),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 18,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1990, 11, 22),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 19,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1993, 08, 22),
                    Type = "Credito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 20,
                    Amount = 202300,
                    Concept = "Sueldo",
                    Date = new DateTime(1995, 11, 22),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },

                new Transaction
                {
                    Transaction_id = 21,
                    Amount = 15155,
                    Concept = "Crédito",
                    Date = new DateTime(2020, 01, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 22,
                    Amount = 4922,
                    Concept = "Efectivo",
                    Date = new DateTime(1999, 04, 14),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 23,
                    Amount = 9340,
                    Concept = "Prestamo",
                    Date = new DateTime(2002, 03, 04),
                    Type = "Crédito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 24,
                    Amount = 3211,
                    Concept = "Sueldo",
                    Date = new DateTime(2013, 05, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 25,
                    Amount = 55552,
                    Concept = "crédito",
                    Date = new DateTime(2022, 02, 18),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 26,
                    Amount = 224,
                    Concept = "Reintegro",
                    Date = new DateTime(1980, 08, 12),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 27,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1990, 07, 24),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 28,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1991, 11, 22),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 29,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1997, 11, 26),
                    Type = "Credito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 30,
                    Amount = 202300,
                    Concept = "Sueldo",
                    Date = new DateTime(1998, 11, 13),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },

                new Transaction
                {
                    Transaction_id = 31,
                    Amount = 15155,
                    Concept = "Crédito",
                    Date = new DateTime(2019, 01, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 32,
                    Amount = 4922,
                    Concept = "Efectivo",
                    Date = new DateTime(1999, 04, 14),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 33,
                    Amount = 9340,
                    Concept = "Prestamo",
                    Date = new DateTime(2002, 03, 04),
                    Type = "Crédito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 34,
                    Amount = 3211,
                    Concept = "Sueldo",
                    Date = new DateTime(2013, 05, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 35,
                    Amount = 55552,
                    Concept = "crédito",
                    Date = new DateTime(2021, 02, 18),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 36,
                    Amount = 224,
                    Concept = "Reintegro",
                    Date = new DateTime(1980, 08, 12),
                    Type = "Debito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 37,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1992, 05, 22),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 38,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1991, 11, 23),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 39,
                    Amount = 202300,
                    Concept = "Pago",
                    Date = new DateTime(1997, 12, 12),
                    Type = "Credito",
                    Account_id = 1,
                    User_id = 1
                },
                new Transaction
                {
                    Transaction_id = 40,
                    Amount = 202300,
                    Concept = "Sueldo",
                    Date = new DateTime(1999, 10, 25),
                    Type = "Efectivo",
                    Account_id = 1,
                    User_id = 1
                }


            );
        });
    }
}