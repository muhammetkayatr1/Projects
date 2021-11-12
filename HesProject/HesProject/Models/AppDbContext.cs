using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<ProlizData> ProlizData { get; set; }
        public DbSet<ActiveStudent> ActiveStudent { get; set; }
        public DbSet<EmployeeHesInfo> EmployeeHesInfo { get; set; }
        public DbSet<EmployeeVaccineInfo> EmployeeVaccineInfo { get; set; }
        public DbSet<StudentVaccineInfo> StudentVaccineInfo { get; set; }
    }
}
