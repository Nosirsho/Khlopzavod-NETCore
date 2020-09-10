using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Models {

    public enum Vid{ 
        Технический, Посевной
    }
    public enum Sbor {
        Ручной, Машинный
    }

    public class Partiya {
        public int PartiyaID { get; set; }
        public string NomerPart { get; set; }
        public int BuntID { get; set; }
        public int SemenaID { get; set; }
        public Vid Vid { get; set; }
        public byte Sort { get; set; }
        public Sbor Sbor { get; set; }

        public Bunt Bunt { get; set; }
        public Semena Semena { get; set; }
        public ICollection<PKvitanciya> PKvitanciyas { get; set; }

    }
}
