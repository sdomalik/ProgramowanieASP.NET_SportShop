﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Manufacturers.Any())
            {
                context.Manufacturers.AddRange(
                    new Manufacturer
                    {
                        Name = "Avon Group",
                        Country = "England"
                    },
                    new Manufacturer
                    {
                        Name = "PJM",
                        Country = "England"
                    }
                );
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kajak",
                        Description = "Łódka przeznaczona dla jednej osoby",
                        Category = "Sporty wodne",
                        Price = 275,
                        Quantity = 2,
                        ManufacturerId = 1
                    },
                    new Product
                    {
                        Name = "Kamizelka ratunkowa",
                        Description = "Chroni i dodaje uroku",
                        Category = "Sporty wodne",
                        Price = 48.95m,
                        Quantity = 4,
                        ManufacturerId = 1
                    },
                    new Product
                    {
                        Name = "Piłka",
                        Description = "Zatwierdzone przez FIFA rozmiar i waga",
                        Category = "Piłka nożna",
                        Price = 19.50m,
                        Quantity = 2,
                        ManufacturerId = 1
                    },
                    new Product
                    {
                        Name = "Flagi narożne",
                        Description = "Nadadzą twojemu boisku profesjonalny wygląd",
                        Category = "Piłka nożna",
                        Price = 34.95m,
                        Quantity = 10,
                        ManufacturerId = 1
                    },
                    new Product
                    {
                        Name = "Stadiom",
                        Description = "Składany stadion na 35 000 osób",
                        Category = "Piłka nożna",
                        Price = 79500,
                        Quantity = 1,
                        ManufacturerId = 1
                    },
                    new Product
                    {
                        Name = "Czapka",
                        Description = "Zwiększa efektywność mózgu o 75%",
                        Category = "Szachy",
                        Price = 16,
                        Quantity = 6,
                        ManufacturerId = 2
                    },
                    new Product
                    {
                        Name = "Niestabilne krzesło",
                        Description = "Zmniejsza szanse przeciwnika",
                        Category = "Szachy",
                        Price = 29.95m,
                        Quantity = 7,
                        ManufacturerId = 2
                    },
                    new Product
                    {
                        Name = "Ludzka szachownica",
                        Description = "Przyjemna gra dla całej rodziny!",
                        Category = "Szachy",
                        Price = 75,
                        Quantity = 13,
                        ManufacturerId = 2
                    },
                    new Product
                    {
                        Name = "Błyszczący król",
                        Description = "Figura pokryta złotem i wysadzana diamentami",
                        Category = "Szachy",
                        Price = 1200,
                        Quantity = 7,
                        ManufacturerId = 2
                    }
                );
                context.SaveChanges();
            }
            
        }
    }
}
