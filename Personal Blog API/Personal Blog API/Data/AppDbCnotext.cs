using Microsoft.EntityFrameworkCore;
using Personal_Blog_API.Modles;

namespace Personal_Blog_API.Data
{
    public class AppDbCnotext : DbContext
    {
        public AppDbCnotext(DbContextOptions options ): base( options )
        {
                
        }


      public DbSet<Article> articles {  get; set; }
    }
}
