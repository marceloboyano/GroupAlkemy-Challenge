using AlkemyWallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.DataAccess.Seeds;

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
                },
                new Catalogue
                {
                    Id = 11,
                    Product_description = "Termotanque",
                    Image = "",
                    Points = 600
                },
                new Catalogue
                {
                    Id = 12,
                    Product_description = "Secaropa",
                    Image = "",
                    Points = 300
                },
                new Catalogue
                {
                    Id = 13,
                    Product_description = "Tostadora",
                    Image = "",
                    Points = 100
                },
                new Catalogue
                {
                    Id = 14,
                    Product_description = "Plancha de pelo",
                    Image = "",
                    Points = 100
                },
                new Catalogue
                {
                    Id = 15,
                    Product_description = "Home Theater",
                    Image = "",
                    Points = 300
                },
                new Catalogue
                {
                    Id = 16,
                    Product_description = "Equipo de Sonido",
                    Image = "",
                    Points = 250
                },
                new Catalogue
                {
                    Id = 17,
                    Product_description = "Calentador Portatil",
                    Image = "",
                    Points = 400
                },
                new Catalogue
                {
                    Id = 18,
                    Product_description = "Televisor Led",
                    Image = "",
                    Points = 800
                },
                new Catalogue
                {
                    Id = 19,
                    Product_description = "Lampara de Pie",
                    Image = "",
                    Points = 50
                },
                new Catalogue
                {
                    Id = 20,
                    Product_description = "Sistema de Audio Portatil",
                    Image = "",
                    Points = 300
                },
                new Catalogue
                {
                    Id = 21,
                    Product_description = "Licuadora",
                    Image = "",
                    Points = 100
                },
                new Catalogue
                {
                    Id = 22,
                    Product_description = "Corta Cesped",
                    Image = "",
                    Points = 350
                },
                new Catalogue
                {
                    Id = 23,
                    Product_description = "Hidrolavadora",
                    Image = "",
                    Points = 200
                },
                new Catalogue
                {
                    Id = 24,
                    Product_description = "Telefono Celular",
                    Image = "",
                    Points = 400
                },
                new Catalogue
                {
                    Id = 25,
                    Product_description = "Generador Electrico",
                    Image = "",
                    Points = 400
                },
                new Catalogue
                {
                    Id = 26,
                    Product_description = "Bomba de Presion",
                    Image = "",
                    Points = 150
                },
                new Catalogue
                {
                    Id = 27,
                    Product_description = "Computadora de Escritorio",
                    Image = "",
                    Points = 800
                },
                new Catalogue
                {
                    Id = 28,
                    Product_description = "Laptop",
                    Image = "",
                    Points = 700
                },
                new Catalogue
                {
                    Id = 29,
                    Product_description = "Monitor UltraWide",
                    Image = "",
                    Points = 250
                },
                new Catalogue
                {
                    Id = 30,
                    Product_description = "Aire Acondicionado",
                    Image = "",
                    Points = 500
                }
            );
        });
    }
}