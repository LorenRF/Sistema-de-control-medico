using Microsoft.EntityFrameworkCore;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Context
{
    public class DBControl_medicoContext : DbContext
    {
        public DBControl_medicoContext()
        {
        }

        public DBControl_medicoContext(DbContextOptions<DBControl_medicoContext> options)
            : base(options)
        {
        }

        public DbSet<GetAltas> getAltas { get; set; }
        public DbSet<GetIngresos> getIngresos { get; set; }
        public DbSet<GetCitas> getCitas { get; set; }
        public DbSet<GetHabitacion> Habitaciones { get; set; }
        public DbSet<GetMedicos> Medicos { get; set; }
        public DbSet<GetPacientes> Pacientes { get; set; }
        public DbSet<SpResult> SpResult { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetAltas>().HasNoKey(); // Indicar que es un tipo sin clave primaria
            modelBuilder.Entity<GetIngresos>().HasNoKey(); // Indicar que es un tipo sin clave primaria
            modelBuilder.Entity<GetCitas>().HasNoKey(); // Indicar que es un tipo sin clave primaria
            modelBuilder.Entity<GetHabitacion>().HasNoKey(); // Indicar que es un tipo sin clave primaria
            modelBuilder.Entity<GetMedicos>().HasNoKey(); // Indicar que es un tipo sin clave primaria
            modelBuilder.Entity<GetPacientes>().HasNoKey(); // Indicar que es un tipo sin clave primaria



            // Configurar otros mapeos, relaciones, etc.
        }


    }
}
