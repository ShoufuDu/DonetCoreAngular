using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleGlossary.Models;

namespace SimpleGlossary.Models
{
    public class SeedData
    {
        public static void SeedDatabase(IApplicationBuilder app)
        {
            DataContext context = app.ApplicationServices.GetRequiredService<DataContext>();

            context.Database.Migrate();
            if (context.Database.GetMigrations().Count() > 0
                && context.Database.GetPendingMigrations().Count() == 0
                && context.Entries.Count() == 0)
            {
                context.Entries.AddRange(
                new Entry
                {
                    Term = "Kayak",
                    Definition = "A boat for one person",
                    Category = "K"
                },
                new Entry
                {
                    Term = "Lifejacket",
                    Definition = "Protective and fashionable",
                    Category = "L"
                },
                new Entry
                {
                    Term = "Soccer Ball",
                    Definition = "FIFA-approved size and weight",
                    Category = "S"
                },
                new Entry
                {
                    Term = "Corner Flags",
                    Definition = "Give your pitch a professional touch",
                    Category = "C"
                },
                new Entry
                {
                    Term = "Stadium",
                    Definition = "Flat-packed 35,000-seat stadium",
                    Category = "S"
                },
                new Entry
                {
                    Term = "Thinking Cap",
                    Definition = "Improve brain efficiency by 75%",
                    Category = "T"
                },
                new Entry
                {
                    Term = "Unsteady Chair",
                    Definition = "Secretly give your opponent a disadvantage",
                    Category = "U"
                },
                new Entry
                {
                    Term = "Human Chess Board",
                    Definition = "A fun game for the family",
                    Category = "H"
                },
                new Entry
                {
                    Term = "Lili Chess Board",
                    Definition = "A fun game for the family",
                    Category = "L"
                },
                new Entry
                {
                    Term = "XxinYi Chess Board",
                    Definition = "A fun game for the family",
                    Category = "X"
                },
                new Entry
                {
                    Term = "TianLina Chess Board",
                    Definition = "A fun game for the family",
                    Category = "T"
                },
                new Entry
                {
                    Term = "Bling-Bling King",
                    Definition = "Gold-plated, diamond-studded King",
                    Category = "B"
                });
                context.SaveChanges();
            }
        }
    }
}

