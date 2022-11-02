using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Entities
{
    //aqui se puede modificar individualmente el Seed (DataFirst) de cada tabla
    //(todavia no esta terminado asi que no va a cargar los datos como data first)
    public class UserEntity : IEntityTypeConfiguration<User>
    {   
            public void Configure(EntityTypeBuilder<User> builder)
            {

            builder.ToTable("User");
            builder.Property(s => s.Id).IsRequired();

            builder.HasKey(x => x.Id);
            builder.HasData(
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
            builder.HasKey(x => x.Id);
            builder.HasData(
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
   

             }
        
    }
}
