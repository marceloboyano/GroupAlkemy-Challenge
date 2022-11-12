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
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 2,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 3,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 4,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                },
                new FixedTermDeposit
                {
                    Id = 5,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 6,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 7,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 8,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                },
                new FixedTermDeposit
                {
                    Id = 9,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 10,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                 new FixedTermDeposit
                 {
                     Id = 11,
                     User_id = 1,
                     Account_id = 3,
                     Creation_date = new DateTime(2020, 01, 25),
                     Amount = 23000,
                     Closing_date = new DateTime(2021, 03, 22)
                 },
                new FixedTermDeposit
                {
                    Id = 12,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 13,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 14,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                },
                new FixedTermDeposit
                {
                    Id = 15,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 16,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 17,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 18,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                },
                new FixedTermDeposit
                {
                    Id = 19,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 20,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                 new FixedTermDeposit
                 {
                     Id = 21,
                     User_id = 1,
                     Account_id = 3,
                     Creation_date = new DateTime(2020, 01, 25),
                     Amount = 23000,
                     Closing_date = new DateTime(2021, 03, 22)
                 },
                new FixedTermDeposit
                {
                    Id = 22,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 23,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 24,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                },
                new FixedTermDeposit
                {
                    Id = 25,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 26,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 27,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 28,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                },
                new FixedTermDeposit
                {
                    Id = 29,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 30,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                 new FixedTermDeposit
                 {
                     Id = 31,
                     User_id = 1,
                     Account_id = 3,
                     Creation_date = new DateTime(2020, 01, 25),
                     Amount = 23000,
                     Closing_date = new DateTime(2021, 03, 22)
                 },
                new FixedTermDeposit
                {
                    Id = 32,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 33,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 34,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                },
                new FixedTermDeposit
                {
                    Id = 35,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 36,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                },
                new FixedTermDeposit
                {
                    Id = 37,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2010, 04, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2011, 04, 8)
                },
                new FixedTermDeposit
                {
                    Id = 38,
                    User_id = 2,
                    Account_id = 2,
                    Creation_date = new DateTime(2018, 01, 10),
                    Amount = 23000,
                    Closing_date = new DateTime(2019, 01, 22)
                },
                new FixedTermDeposit
                {
                    Id = 39,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2020, 01, 25),
                    Amount = 23000,
                    Closing_date = new DateTime(2021, 03, 22)
                },
                new FixedTermDeposit
                {
                    Id = 40,
                    User_id = 1,
                    Account_id = 3,
                    Creation_date = new DateTime(2021, 12, 19),
                    Amount = 23000,
                    Closing_date = new DateTime(2022, 06, 22)
                }

            );
        });
    }
}