using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectD
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Training> Trainings { get; set; }
    }
    public class Training
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public string WeekTraining { get; set; }
    }
}
