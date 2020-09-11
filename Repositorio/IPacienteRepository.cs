using System.Collections.Generic;
using apiPacientes.Models;

namespace apiPacientes.Repositorio
{
    public interface IPacienteRepository
    {
         //adicionar
         void Add(Paciente paciente);
         //recuperar uma lista
         IEnumerable<Paciente> GetAll();
         //busca por id
         Paciente Find(long id);
         //remove
         void Remove(long id);
         //update
         void Update(Paciente paciente);
    }
}