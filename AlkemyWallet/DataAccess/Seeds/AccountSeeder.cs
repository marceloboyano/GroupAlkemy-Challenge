using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds
{
    public class AccountSeeder
    {
        //falta el interface para cargar todo a dbcontext de una 
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
                        CreationDate = new DateTime(1995, 11, 19),
                        Money = 10050,
                        IsBlocked = false,
                        User_id = 3
                    },
                    new Account
                    {
                        Id = 4,
                        CreationDate = new DateTime(1995, 11, 19),
                        Money = 502221,
                        IsBlocked = false,
                        User_id = 3
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
        }
    }

}
