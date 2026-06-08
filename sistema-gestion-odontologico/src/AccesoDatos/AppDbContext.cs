using Microsoft.EntityFrameworkCore;
using CapaEntidades;
using Microsoft.Extensions.Options;

namespace CapaDatos
{
    public class AppDbContext : DbContext
    {
        public DbSet<CliPlaUser> CliPlaUser { get; set; }  
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<CliInterEnc> CliInterEnc { get; set; }
        public DbSet<ObSocial> ObSocial { get; set; }
        public DbSet<CliPlaInterDet> CliPlaInterDet { get; set; }
        public DbSet<CliPlanillasEnc> CliPlanillasEnc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=-----\\------;Database=Capsule;User Id=---;Password=------;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Le indica a EF que use exactamente la tabla "CliPlaUser" del schema "dbo"
            modelBuilder.Entity<CliPlaUser>().ToTable("CliPlaUser");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Medicos>().ToTable("Medicos");            
            modelBuilder.Entity<ObSocial>().ToTable("ObSocial");
            modelBuilder.Entity<CliInterEnc>().ToTable("CliInterEnc");
            modelBuilder.Entity<CliPlaInterDet>().ToTable("CliPlaInterDet");
            modelBuilder.Entity<CliPlanillasEnc>().ToTable("CliPlanillasEnc");
        }
    }
}
