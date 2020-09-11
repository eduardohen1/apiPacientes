namespace apiPacientes.Models
{
    public class Paciente
    {
        public long id {get; set;}
        public int idPessoa {get; set;}
        public string data_entrada { get; set; }
        public string comorbidade {get; set;}
        public int grau{get;set;}
    }
}