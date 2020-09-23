using KlopZavod.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            var assocs = new Assoc[] {
                        new Assoc { Name="А.Чумаев", Jamoat = "Исфисор", SocrName = "АЧ" },
                        new Assoc { Name="Т.Кушатов", Jamoat = "Сомгар", SocrName = "ТК" },
                        new Assoc { Name="С.Урунхучаев", Jamoat = "Унчи", SocrName = "СУ" }
                    };
            foreach (Assoc s in assocs)
            {
                context.Assoc.Add(s);
            }
            context.SaveChanges();

            var rayons = new Rayon[] {
                        new Rayon { Name="н.Б.Гафуров" },
                        new Rayon { Name="н.Ч.Расулов" },
                        new Rayon { Name="н.Зафаробод" }
                    };
            foreach (Rayon s in rayons)
            {
                context.Rayon.Add(s);
            }
            context.SaveChanges();

            var khojagis = new Khojagi[] {
                        new Khojagi { Name="ХД Расулсаркор", Director="Расулов К.", RMA=635456585, Phone = 929299229, Ga =10,  RayonID=1, AssocID=1 },
                        new Khojagi { Name="ХД Шарифасаркор", Director="Шарифов С.", RMA=635254541, Phone = 927254574, Ga =5,  RayonID=1, AssocID=2 },
                        new Khojagi { Name="ичор. Каримов Зариф", Director="Каримов З.", RMA=635221111, Phone = 927772354, Ga =4,  RayonID=1, AssocID=3 }

                    };
            foreach (Khojagi s in khojagis)
            {
                context.Khojagi.Add(s);
            }
            context.SaveChanges();

            var bunts = new Bunt[] {
                        new Bunt { Name="Бунт-1" },
                        new Bunt { Name="Бунт-2" },
                        new Bunt { Name="Склад-1" }
                    };
            foreach (Bunt s in bunts)
            {
                context.Bunt.Add(s);
            }
            context.SaveChanges();

            var semenas = new Semena[] {
                        new Semena { Name="Хучанд-67"},
                        new Semena { Name="Ориёи"},
                        new Semena { Name="Дусти"}
                    };
            foreach (Semena s in semenas)
            {
                context.Semena.Add(s);
            }
            context.SaveChanges();

            var partiyas = new Partiya[] {
                        new Partiya { NomerPart = "1", SemenaID=1, BuntID =1, Sort = 1, Sbor =Sbor.Ручной, Vid = Vid.Технический },
                        new Partiya { NomerPart = "2", SemenaID=2, BuntID =2, Sort = 1, Sbor =Sbor.Ручной, Vid = Vid.Технический },
                        new Partiya { NomerPart = "3", SemenaID=1, BuntID =3, Sort = 1, Sbor =Sbor.Ручной, Vid = Vid.Посевной },

                    };
            foreach (Partiya s in partiyas)
            {
                context.Partiya.Add(s);
            }
            context.SaveChanges();
        }

    }
}
