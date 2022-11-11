using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds
{
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
        }
    }

}