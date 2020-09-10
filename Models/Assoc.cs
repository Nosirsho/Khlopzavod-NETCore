using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Models {
    public class Assoc {
        public int AssocID { get; set; }
        public string Name { get; set; }
        public string SocrName { get; set; }
        public string Jamoat { get; set; }
        public ICollection<Khojagi> Khojagis { get; set; }

    }
}
