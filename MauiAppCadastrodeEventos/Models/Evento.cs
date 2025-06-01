namespace MauiAppCadastrodeEventos.Models
{
    public class Evento
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Local { get; set; }

        public int Duracao => (DataTermino - DataInicio).Days + 1;
        public double CustoTotal(int numeroParticipantes, double custoPorParticipante)
        {
            return numeroParticipantes * custoPorParticipante;
        }
    }
}
