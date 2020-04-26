using Microsoft.EntityFrameworkCore;

namespace SWEProject.Models
{
    public class Table4UContext:DbContext
    {
        public Table4UContext(DbContextOptions opts):base(opts)
        {

        }
        
        public DbSet<Lokal> Lokali { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Dogadjaj> Dogadjaji { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Sto> Stolovi { get; set; }
        public DbSet<Recenzija> Recenzije {get; set;}
        
    }


}