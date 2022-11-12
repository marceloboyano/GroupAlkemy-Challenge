using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds;

public class UserSeeder
{
    private readonly ModelBuilder _modelBuilder;

    public UserSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void SeedUser()
    {
        _modelBuilder.Entity<User>(p =>
        {
            p.HasData(
                new User
                {
                    Id = 1,
                    First_name = "Clint",
                    Last_name = "Eastwood",
                    Email = "clint@eastwood.com",
                    Password = "$2b$10$DjsYH6P2iczga6DFAAVf/Oulu1f9Qdlw24w0Lfej3aNnQx.eqato2",
                    Points = 500,
                    Rol_id = 2
                },
                new User
                {
                    Id = 2,
                    First_name = "Arnold",
                    Last_name = "Schwarzenegger",
                    Email = "arnoldsg@skynet.com",
                    Password = "$2b$10$dvsbNpgI0E0v9X5D7r9h2un6DFsI8mx2RePLUOUaMMTWQr3hlU522",
                    Points = 2000,
                    Rol_id = 1
                },
                new User
                {
                    Id = 3,
                    First_name = "Sylvester",
                    Last_name = "Stallone",
                    Email = "sylvesters@hollywood.com",
                    Password = "$2b$10$zUJTo0YB6ltWZFwFUw3Ek.47UuzqwFNI366GhKoTJZlUQkPS..mNu",
                    Points = 2000,
                    Rol_id = 3
                }
            );
        });
    }
}