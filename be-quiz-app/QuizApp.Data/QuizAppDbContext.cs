using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class QuizAppDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MusicConfiguration());
            builder.ApplyConfiguration(new ArtistConfiguration());
        }

    }
}
