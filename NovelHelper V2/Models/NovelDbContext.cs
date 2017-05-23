using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NovelHelper_V2.Models
{
    public class NovelDbContext : DbContext
    {
        public NovelDbContext() : base()
        {

        }

        public DbSet<Novel> Novels { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}