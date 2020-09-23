using KlopZavod.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace KlopZavod.Data {
    public static class DbInitializer2 {
        public static void Initialize(ZavodContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Assoc.Any())
                context.Assoc.AddRange(Assocs.Select(c => c.Value));
            if (!context.Rayon.Any())
                context.Rayon.AddRange(Rayons.Select(c => c.Value));
            if (!context.Khojagi.Any())
                context.Khojagi.AddRange(Khojagis.Select(c => c.Value));
            if (!context.Bunt.Any())
                context.Bunt.AddRange(Bunts.Select(c => c.Value));
            if (!context.Semena.Any())
                context.Semena.AddRange(Semenas.Select(c => c.Value));
            if (!context.Partiya.Any())
                context.Partiya.AddRange(Partiyas.Select(c => c.Value));
            context.SaveChanges();
        }

        private static Dictionary<string, Assoc> assoc;
        public static Dictionary<string, Assoc> Assocs {
            get {
                if (assoc == null) {
                    var list = new Assoc[] {
                        new Assoc { Name="А.Чумаев", Jamoat = "Исфисор", SocrName = "АЧ" },
                        new Assoc { Name="Т.Кушатов", Jamoat = "Сомгар", SocrName = "ТК" },
                        new Assoc { Name="С.Урунхучаев", Jamoat = "Унчи", SocrName = "СУ" }
                    };

                    assoc = new Dictionary<string, Assoc>();
                    foreach (Assoc item in list)
                        assoc.Add(item.Name, item);
                    
                }
                return assoc;
            }
        }

        private static Dictionary<string, Rayon> rayon;
        public static Dictionary<string, Rayon> Rayons
        {
            get
            {
                if (rayon == null)
                {
                    var list = new Rayon[] {
                        new Rayon { Name="н.Б.Гафуров" },
                        new Rayon { Name="н.Ч.Расулов" },
                        new Rayon { Name="н.Зафаробод" }
                    };

                    rayon = new Dictionary<string, Rayon>();
                    foreach (Rayon item in list)
                        rayon.Add(item.Name, item);

                }
                return rayon;
            }
        }

        private static Dictionary<string, Khojagi> khojagi;
        public static Dictionary<string, Khojagi> Khojagis
        {
            get
            {
                if (khojagi == null)
                {
                    var list = new Khojagi[] {
                        new Khojagi { Name="ХД Расулсаркор", Director="Расулов К.", RMA=635456585, Phone = 929299229, Ga =10,  RayonID=1, AssocID=1 },
                        new Khojagi { Name="ХД Шарифасаркор", Director="Шарифов С.", RMA=635254541, Phone = 927254574, Ga =5,  RayonID=1, AssocID=2 },
                        new Khojagi { Name="ичор. Каримов Зариф", Director="Каримов З.", RMA=635221111, Phone = 927772354, Ga =4,  RayonID=1, AssocID=3 }
                        
                    };

                    khojagi = new Dictionary<string, Khojagi>();
                    foreach (Khojagi item in list)
                        khojagi.Add(item.Name, item);

                }
                return khojagi;
            }
        }

        private static Dictionary<string, Bunt> bunt;
        public static Dictionary<string, Bunt> Bunts
        {
            get
            {
                if (bunt == null)
                {
                    var list = new Bunt[] {
                        new Bunt { Name="Бунт-1" },
                        new Bunt { Name="Бунт-2" },
                        new Bunt { Name="Склад-1" }
                    };

                    bunt = new Dictionary<string, Bunt>();
                    foreach (Bunt item in list)
                        bunt.Add(item.Name, item);

                }
                return bunt;
            }
        }

        private static Dictionary<string, Semena> semena;
        public static Dictionary<string, Semena> Semenas
        {
            get
            {
                if (semena == null)
                {
                    var list = new Semena[] {
                        new Semena { Name="Хучанд-67"},
                        new Semena { Name="Ориёи"},
                        new Semena { Name="Дусти"}
                    };

                    semena = new Dictionary<string, Semena>();
                    foreach (Semena item in list)
                        semena.Add(item.Name, item);

                }
                return semena;
            }
        }

        private static Dictionary<string, Partiya> partiya;
        public static Dictionary<string, Partiya> Partiyas
        {
            get
            {
                if (partiya == null)
                {
                    var list = new Partiya[] {
                        new Partiya { NomerPart = "1", SemenaID=1, BuntID =1, Sort = 1, Sbor =Sbor.Ручной, Vid = Vid.Технический },
                        new Partiya { NomerPart = "2", SemenaID=2, BuntID =2, Sort = 1, Sbor =Sbor.Ручной, Vid = Vid.Технический },
                        new Partiya { NomerPart = "3", SemenaID=1, BuntID =3, Sort = 1, Sbor =Sbor.Ручной, Vid = Vid.Посевной },

                    };

                    partiya = new Dictionary<string, Partiya>();
                    foreach (Partiya item in list)
                        partiya.Add(item.NomerPart, item);

                }
                return partiya;
            }
        }




    }
}
