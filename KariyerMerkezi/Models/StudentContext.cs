using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerMerkezi.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Grup_Katilimci_Etkinlik> Grup_Katilimci_Etkinlik { get; set; }
        public DbSet<Etkinlik> Etkinlik { get; set; }
        public DbSet<Grup> Grup { get; set; }
        public DbSet<Katilimci> Katilimci { get; set; }
        public DbSet<Katilimci_Etkinlik> Katilimci_Etkinlik { get; set; }
    }
}