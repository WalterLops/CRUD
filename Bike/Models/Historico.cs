using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeVale.Models
{
    public class Historico
    {
        public int IdHistorico { get; set; }
        public string DataAlugel { get; set; }
        public int TempoAluguel { get; set; }
        public string LocalPasseio { get; set; }

        public Historico(int idHistorico, string dataAlugel, int tempoAluguel, string localPasseio)
        {
            IdHistorico = idHistorico;
            DataAlugel = dataAlugel;
            TempoAluguel = tempoAluguel;
            LocalPasseio = localPasseio;
        }
    }
}
