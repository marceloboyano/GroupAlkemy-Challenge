using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds;

public class RoleSeeder
{
    private readonly ModelBuilder _modelBuilder;

    public RoleSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void SeedRole()
    {
        _modelBuilder.Entity<Role>(p =>
        {
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
        });
    }
}