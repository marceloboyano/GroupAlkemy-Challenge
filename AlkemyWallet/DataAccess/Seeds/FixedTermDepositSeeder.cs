using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds;

public class FixedTermDepositSeeder
{
    private readonly ModelBuilder _modelBuilder;

    public FixedTermDepositSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void SeedFixedTermDeposit()
    {
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
    }
}