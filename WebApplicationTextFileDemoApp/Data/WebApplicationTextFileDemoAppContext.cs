using Microsoft.EntityFrameworkCore;
using DbCoreLibrary;



namespace WebApplicationTextFileDemoApp.Data
{
    public class WebApplicationTextFileDemoAppContext : DbContext
    {
        
        public WebApplicationTextFileDemoAppContext (DbContextOptions<WebApplicationTextFileDemoAppContext> options)
            : base(options)
        {
        }

        public DbSet<DbCoreLibrary.SerializedFileDto> SerializedFile { get; set; }

        public DbSet<DbCoreLibrary.SerializedFile> SerializedFile_1 { get; set; }
    }
}
