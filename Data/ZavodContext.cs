using KlopZavod.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlopZavod.Data {
    public class ZavodContext : DbContext {
        public ZavodContext(DbContextOptions<ZavodContext> options):base(options) {

        }
        public DbSet<Assoc> Assoc { get; set; }
        public DbSet<Khojagi> Khojagi { get; set; }
        public DbSet<KlopZavod.Models.Rayon> Rayon { get; set; }
        public DbSet<KlopZavod.Models.Bunt> Bunt { get; set; }
        public DbSet<KlopZavod.Models.Semena> Semena { get; set; }
        public DbSet<KlopZavod.Models.Partiya> Partiya { get; set; }
        public DbSet<KlopZavod.Models.PKvitanciya> PKvitanciya { get; set; }
    }
}
