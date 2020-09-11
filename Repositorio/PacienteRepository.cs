using System.Collections.Generic;
using System.Linq;
using apiPacientes.Models;

namespace apiPacientes.Repositorio
{
   public class PacienteRepository : IPacienteRepository
   {
      private readonly PacienteDbContext contexto;
      public PacienteRepository(PacienteDbContext contexto){
          this.contexto = contexto;
      }
      public void Add(Paciente paciente)
      {
         contexto.Pacientes.Add(paciente);
         contexto.SaveChanges();
      }

      public Paciente Find(long id)
      {
         return contexto.Pacientes.FirstOrDefault(p => p.id == id);
      }

      public IEnumerable<Paciente> GetAll()
      {
         return contexto.Pacientes.ToList();
      }

      public void Remove(long id)
      {
         var pacienteRemove = contexto.Pacientes.First(p => p.id == id);
         contexto.Pacientes.Remove(pacienteRemove);
         contexto.SaveChanges();
      }

      public void Update(Paciente paciente)
      {
         contexto.Pacientes.Update(paciente);
         contexto.SaveChanges();
      }
   }
}