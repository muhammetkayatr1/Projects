using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCenter.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<EmployeeVaccineInfo> EmployeeVaccineInfo { get; set; }
        public DbSet<StudentVaccineInfo> StudentVaccineInfo { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ProlizData> ProlizData { get; set; }
    }
}
