using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Models {
    public class PKvitanciya {
        public int PKvitanciyaID { get; set; }
        public int NomerPK { get; set; }
        public DateTime Data { get; set; }
        public int NomerNakl { get; set; }
        public int KhojagiID { get; set; }
        public int PartiyaID { get; set; }
        public int FizVes { get; set; }
        public double Zasor { get; set; } = 2;
        public double Vlagn { get; set; } = 9;


        public Khojagi Khojagi { get; set; }
        public Partiya Partiya { get; set; }

        public double getRaschVes() {         // Расчетный вес
            double raschVes = (100 - Zasor) / 98 * FizVes;
            return raschVes;
        }

        public int getKondMass()           // Кондиционная масса
        {
            int kondMass = (int)(109 / (100 + Vlagn) * getRaschVes());
            return kondMass;
        }
    }
}
