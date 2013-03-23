using System;
using System.Data.Entity;

namespace Blog.Models
{
    public class Blogi
    {
        public int Id { set; get; }
        public string Nimi { set; get; }
        public string Otsikko { set; get; }
        public string Teksti { set; get; }
    }

    public class BlogiDBContext : DbContext
    {
        public DbSet<Blogi> Blogit { get; set; }
    }
}