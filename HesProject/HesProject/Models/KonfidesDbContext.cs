using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models
{
    public class KonfidesDbContext : DbContext
    {
        public KonfidesDbContext(DbContextOptions<KonfidesDbContext> options) : base(options) { }

        //public DbSet<Bo_Card> Bo_Card { get; set; }
        //public DbSet<Card_Parameters> Card_Parameters { get; set; }
        //public DbSet<Campus_Core_CampusCardOwnership> Campus_Core_CampusCardOwnership { get; set; }
        //public DbSet<SharedKernel_CardOwnershipBase> SharedKernel_CardOwnershipBase { get; set; }
        //public DbSet<Bo_Individual> Bo_Individual { get; set; }
        //public DbSet<SharedKernel_PersonalityBase> SharedKernel_PersonalityBase { get; set; }
        //public DbSet<SharedKernel_PersonalityType> SharedKernel_PersonalityType { get; set; }
        //public DbSet<SharedKernel_Position> SharedKernel_Position { get; set; }
        //public DbSet<SharedKernel_Tier> SharedKernel_Tier { get; set; }
        //public DbSet<Campus_Core_BlacklistingReason> Campus_Core_BlacklistingReason { get; set; }
        //public DbSet<TerminalEODGroup> TerminalEODGroup { get; set; }

        //public DbSet<Campus_Core_CardBlacklistingUpdateOrder> Campus_Core_CardBlacklistingUpdateOrder { get; set; }
    }
}
