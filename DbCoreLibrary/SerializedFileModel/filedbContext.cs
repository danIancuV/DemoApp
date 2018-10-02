using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbCoreLibrary
{
    public partial class FiledbContext : DbContext
    {
        public FiledbContext()
        {
            
        }

        public FiledbContext(DbContextOptions<FiledbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SerializedFile> SerializedFile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:filedb.database.windows.net,1433;Initial Catalog=filedb;Persist Security Info=False;User ID=daniancu;Password=Fishing19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            */
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
