using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FileClassLibrary;

namespace WebApplicationTextFileDemoApp.Models
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
