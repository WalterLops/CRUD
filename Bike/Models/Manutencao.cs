using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeVale.Models
{
    public class Manutencao
    {
        public int IdManutencao { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string DataManuencao { get; set; }
    }
}
