using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalicAbilities.Models
{
    public class AbilitiesDbContext : DbContext
    {
        public AbilitiesDbContext(DbContextOptions<AbilitiesDbContext> options) : base(options) { }
        public DbSet<View_HalicinYetenekleri_FormBuilder> View_HalicinYetenekleri_FormBuilder { get; set; }
    }
}
