using apiPacientes.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace apiPacientes.Controllers
{
    [Route("api/[Controller]")]
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository pacienteRepository;
        public PacienteController(IPacienteRepository pacienteRepository){
            this.pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public string GetAll(){
            return "Olá!";
        }

        [HttpGet("{id}", Name="GetPaciente")]
        public string GetPacienteById(long id){
            return "<hr>Paciente: " + id;
        }

    }
}