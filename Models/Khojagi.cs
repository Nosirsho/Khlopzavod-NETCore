using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("UploadFile")]
        public IFormFile ImageFile { get; set; }
        public Assoc Assoc { get; set; }
        public Rayon Rayon { get; set; }
        public ICollection<PKvitanciya> PKvitanciyas { get; set; }

    }
}
