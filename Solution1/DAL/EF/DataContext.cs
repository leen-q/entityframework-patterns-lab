using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class DataContext : DbContext
    {
        public DbSet<PersonalData> Personaldata { get; set; }
        public DbSet<WorkData> Workdata { get; set; }
        public DbSet<Message> Message { get; set; }​
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
