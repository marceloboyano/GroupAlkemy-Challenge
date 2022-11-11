using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds
{
    public class CatalogueSeeder
    {
      
        private readonly ModelBuilder _modelBuilder;

        public CatalogueSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void SeedCatalogue()
        {

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

}
