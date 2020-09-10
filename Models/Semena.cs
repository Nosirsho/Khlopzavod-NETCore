using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Models {
    public class Semena {
        public int SemenaID { get; set; }
        public string Name { get; set; }
        public ICollection<Partiya> Partiyas { get; set; }
    }
}
