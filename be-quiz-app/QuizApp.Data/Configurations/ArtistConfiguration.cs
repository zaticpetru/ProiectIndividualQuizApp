using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .HasKey(a => a.Id);
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();
            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder
                .ToTable("Artists");
        }
    }
}
