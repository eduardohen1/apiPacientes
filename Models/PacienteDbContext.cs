using Microsoft.EntityFrameworkCore;

namespace apiPacientes.Models
{
    public class PacienteDbContext : DbContext
    {
        public PacienteDbContext(DbContextOptions<PacienteDbContext> options) : base(options){}
        public DbSet<Paciente> Pacientes{get; set;}
    }
}