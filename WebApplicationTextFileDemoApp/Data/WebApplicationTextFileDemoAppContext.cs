using Microsoft.EntityFrameworkCore;



namespace WebApplicationTextFileDemoApp.Data
{
    public class WebApplicationTextFileDemoAppContext : DbContext
    {
        public WebApplicationTextFileDemoAppContext (DbContextOptions<WebApplicationTextFileDemoAppContext> options)
            : base(options)
        {
        }

        public DbSet<FileClassLibrary.SerializedFileDto> SerializedFile { get; set; }
    }
}
