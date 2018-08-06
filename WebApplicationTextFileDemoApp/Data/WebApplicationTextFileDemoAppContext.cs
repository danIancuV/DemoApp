using Microsoft.EntityFrameworkCore;
using FileClassLibrary;



namespace WebApplicationTextFileDemoApp.Data
{
    public class WebApplicationTextFileDemoAppContext : DbContext
    {
        
        public WebApplicationTextFileDemoAppContext (DbContextOptions<WebApplicationTextFileDemoAppContext> options)
            : base(options)
        {
        }

        public DbSet<FileClassLibrary.SerializedFileDto> SerializedFile { get; set; }

        public DbSet<FileClassLibrary.SerializedFile> SerializedFile_1 { get; set; }
    }
}
