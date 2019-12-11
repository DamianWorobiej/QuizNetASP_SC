using Microsoft.EntityFrameworkCore;
using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetASPKolo.DataAccess
{
    public class EFDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }
    }
}
