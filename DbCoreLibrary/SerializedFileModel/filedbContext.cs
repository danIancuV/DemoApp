using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbCoreLibrary.SerializedFileModel
{
    public partial class filedbContext : DbContext
    {
        public filedbContext()
        {
        }

        public filedbContext(DbContextOptions<filedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SerializedFile> SerializedFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=PC1021\\SQLEXPRESS;Database=filedb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SerializedFile>(entity =>
            {
                entity.Property(e => e.Extension).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
