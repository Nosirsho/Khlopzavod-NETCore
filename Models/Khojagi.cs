using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Models {
    public class Khojagi {
        public int KhojagiID { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public int RMA { get; set; }
        public int Phone { get; set; }
        public int Ga { get; set; }
        public int? AssocID { get; set; }
        public int? RayonID { get; set; }
        public Assoc Assoc { get; set; }
        public Rayon Rayon { get; set; }
        public ICollection<PKvitanciya> PKvitanciyas { get; set; }

    }
}
