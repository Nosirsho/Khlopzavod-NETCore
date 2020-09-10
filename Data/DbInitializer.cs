using KlopZavod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Data {
    public static class DbInitializer {
        public static void Initialize(ZavodContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Assoc.Any())
            {
                return;   // DB has been seeded
            }

            var assocs = new Assoc[]
            {
                new Assoc{ Name="Д.Азизов", Jamoat="Кистакуз"},
                new Assoc{ Name="Т.Кушатов", Jamoat="Исмоил"},
                new Assoc{ Name="С.Урунхучаев", Jamoat="Унчи"}

            };
            foreach (Assoc s in assocs)
            {
                context.Assoc.Add(s);
            }
            context.SaveChanges();

            var khojagis = new Khojagi[]
            {
                new Khojagi{ Name="ХД Хакимов Домулло", Ga = 4, AssocID=0, },
                new Khojagi{ Name="ТК Бомирозоев Наим", Ga = 3, AssocID=1},
                new Khojagi{ Name="ТК Курбонкулов Вайдулло", Ga = 7, AssocID=1},
                new Khojagi{ Name="ичор.Эргашев Назар", Ga = 5, AssocID=2}
            };
            foreach (Khojagi k in khojagis)
            {
                context.Khojagi.Add(k);
            }
            context.SaveChanges();

        }
    }
}
