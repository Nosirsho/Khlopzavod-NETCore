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
        public float Zasor { get; set; }
        public float Vlagn { get; set; }


        public Khojagi Khojagi { get; set; }
        public Partiya Partiya { get; set; }
    }
}
