using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Models {
    public class Rayon {
        public int RayonID { get; set; }
        public string Name { get; set; }
        public ICollection<Khojagi> Khojagis { get; set; }
    }
}
