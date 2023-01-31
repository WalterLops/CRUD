using BikeVale.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeVale.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto>options) :base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Atendente> Atendente { get; set;}
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Manutencao> Manutencao { get; set;}
        public DbSet<Aluga> Aluga { get; set; }
        public DbSet<Possui> Possui { get; set; }
    }
}
