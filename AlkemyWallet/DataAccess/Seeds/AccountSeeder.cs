using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds;

public class AccountSeeder
{
    private readonly ModelBuilder _modelBuilder;

    public AccountSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void SeedAccount()
    {
        _modelBuilder.Entity<Account>(p =>
        {
            p.HasData(
                new Account
                {
                    Id = 1,
                    CreationDate = new DateTime(1995, 11, 19),
                    Money = 150000,
                    IsBlocked = false,
                    User_id = 2
                },
                new Account
                {
                    Id = 2,
                    CreationDate = new DateTime(2021, 12, 19),
                    Money = 50,
                    IsBlocked = true,
                    User_id = 2
                },
                new Account
                {
                    Id = 3,
                    CreationDate = new DateTime(1995, 09, 19),
                    Money = 1050,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 4,
                    CreationDate = new DateTime(1995, 11, 19),
                    Money = 51234,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 5,
                    CreationDate = new DateTime(2018, 01, 10),
                    Money = 1224,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 6,
                    CreationDate = new DateTime(2001, 05, 03),
                    Money = 25040,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 7,
                    CreationDate = new DateTime(1995, 10, 19),
                    Money = 55553,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 8,
                    CreationDate = new DateTime(2012, 12, 19),
                    Money = 50,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 9,
                    CreationDate = new DateTime(1942, 12, 19),
                    Money = 120,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 10,
                    CreationDate = new DateTime(1995, 11, 19),
                    Money = 54311,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 11,
                    CreationDate = new DateTime(2018, 01, 10),
                    Money = 3333,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 12,
                    CreationDate = new DateTime(2013, 05, 05),
                    Money = 231,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 13,
                    CreationDate = new DateTime(1995, 09, 19),
                    Money = 1050,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 14,
                    CreationDate = new DateTime(1995, 11, 19),
                    Money = 51234,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 15,
                    CreationDate = new DateTime(2018, 01, 10),
                    Money = 1224,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 16,
                    CreationDate = new DateTime(2001, 05, 03),
                    Money = 25040,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 17,
                    CreationDate = new DateTime(1995, 10, 19),
                    Money = 55553,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 18,
                    CreationDate = new DateTime(2012, 12, 19),
                    Money = 50,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 19,
                    CreationDate = new DateTime(1942, 12, 19),
                    Money = 120,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 20,
                    CreationDate = new DateTime(1995, 11, 19),
                    Money = 54311,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 21,
                    CreationDate = new DateTime(2018, 01, 10),
                    Money = 3333,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 22,
                    CreationDate = new DateTime(2013, 05, 05),
                    Money = 231,
                    IsBlocked = false,
                    User_id = 1
                },

                new Account
                {
                    Id = 23,
                    CreationDate = new DateTime(1998, 09, 15),
                    Money = 1050,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 24,
                    CreationDate = new DateTime(1999, 11, 17),
                    Money = 51234,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 25,
                    CreationDate = new DateTime(2018, 01, 18),
                    Money = 1224,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 26,
                    CreationDate = new DateTime(2011, 05, 08),
                    Money = 25040,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 27,
                    CreationDate = new DateTime(1985, 10, 19),
                    Money = 55553,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 28,
                    CreationDate = new DateTime(2022, 05, 09),
                    Money = 50,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 29,
                    CreationDate = new DateTime(1967, 12, 29),
                    Money = 120,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 30,
                    CreationDate = new DateTime(1978, 11, 24),
                    Money = 54311,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 31,
                    CreationDate = new DateTime(2020, 01, 25),
                    Money = 3333,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 32,
                    CreationDate = new DateTime(2019, 05, 23),
                    Money = 231,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 33,
                    CreationDate = new DateTime(1992, 09, 24),
                    Money = 1050,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 34,
                    CreationDate = new DateTime(1991, 11, 10),
                    Money = 51234,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 35,
                    CreationDate = new DateTime(2017, 01, 04),
                    Money = 1224,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 36,
                    CreationDate = new DateTime(2007, 05, 05),
                    Money = 25040,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 37,
                    CreationDate = new DateTime(1985, 10, 03),
                    Money = 55553,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 38,
                    CreationDate = new DateTime(2008, 12, 01),
                    Money = 50,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 39,
                    CreationDate = new DateTime(1981, 12, 15),
                    Money = 120,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 40,
                    CreationDate = new DateTime(1998, 11, 17),
                    Money = 54311,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 41,
                    CreationDate = new DateTime(2018, 01, 10),
                    Money = 3333,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 42,
                    CreationDate = new DateTime(2013, 05, 16),
                    Money = 231,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 43,
                    CreationDate = new DateTime(1995, 09, 18),
                    Money = 1050,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 44,
                    CreationDate = new DateTime(1995, 11, 20),
                    Money = 51234,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 45,
                    CreationDate = new DateTime(2018, 01, 25),
                    Money = 1224,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 46,
                    CreationDate = new DateTime(2001, 05, 30),
                    Money = 25040,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 47,
                    CreationDate = new DateTime(1996, 01, 05),
                    Money = 55553,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 48,
                    CreationDate = new DateTime(2015, 02, 15),
                    Money = 50,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 49,
                    CreationDate = new DateTime(1976, 09, 22),
                    Money = 120,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 50,
                    CreationDate = new DateTime(1998, 12, 24),
                    Money = 54311,
                    IsBlocked = false,
                    User_id = 1
                },
                new Account
                {
                    Id = 51,
                    CreationDate = new DateTime(2022, 01, 10),
                    Money = 3333,
                    IsBlocked = true,
                    User_id = 1
                },
                new Account
                {
                    Id = 52,
                    CreationDate = new DateTime(2012, 04, 03),
                    Money = 231,
                    IsBlocked = false,
                    User_id = 1
                }
            );
        });
    }
}