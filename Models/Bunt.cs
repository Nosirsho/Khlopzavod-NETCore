using Microsoft.AspNetCore.ResponseCompression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Models {
    
    public class Bunt {
        public int BuntID { get; set; }
        public string Name { get; set; }

        public ICollection<Partiya> Partiyas { get; set; }
    }
}
