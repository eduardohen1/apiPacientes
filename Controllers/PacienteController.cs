using System.Collections.Generic;
using apiPacientes.Models;
using apiPacientes.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace apiPacientes.Controllers
{
    [Route("api/[Controller]")]
    public class PacientesController : Controller
    {
        //injeção de dependencia
        private readonly IPacienteRepository pacienteRepository; 
        public PacientesController(IPacienteRepository pacienteRepository){
            this.pacienteRepository = pacienteRepository;
        }
        /*
        [HttpGet]
        public string GetAll(){
            return "Olá!";
        }
        [HttpGet("{id}", Name="GetPaciente")]
        public string GetPacienteById(long id){
            return "<hr>Paciente: " + id;
        }
        */
        [HttpGet]
        public IEnumerable<Paciente> GetAll(){
            return pacienteRepository.GetAll();
        }

        [HttpGet("{id}", Name="GetPaciente")]
        public IActionResult GetById(long id){
            var paciente = pacienteRepository.Find(id);
            if(paciente == null)
                return NotFound(); //status code 404
            return new ObjectResult(paciente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Paciente paciente){
            if(paciente == null)
                return BadRequest(); //status code 400
            pacienteRepository.Add(paciente);
            return CreatedAtRoute("GetPaciente", new{id=paciente.id}, paciente);
        }
        
        [HttpPut]
        public IActionResult Update(long id,[FromBody] Paciente paciente){
            var pacienteUp = pacienteRepository.Find(id);
            if(pacienteUp == null)
                return NotFound(); 
            if(paciente == null || paciente.id != id)
                return BadRequest();
            
            //regra de negócio
            //Só vou atualizar 2 campos: Comorbidade e Grau.
            pacienteUp.comorbidade = paciente.comorbidade;
            pacienteUp.grau        = paciente.grau;
            pacienteRepository.Update(pacienteUp);
            //status code 204 o servidor processou a requisição
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            var paciente = pacienteRepository.Find(id);
            if(paciente == null)
                return NotFound();
            pacienteRepository.Remove(id);
            return new NoContentResult();
        }

    }
}