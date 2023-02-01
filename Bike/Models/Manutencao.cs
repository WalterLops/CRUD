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

        public Manutencao(int idManutencao, string descricao, double preco, string dataManuencao)
        {
            IdManutencao = idManutencao;
            Descricao = descricao;
            Preco = preco;
            DataManuencao = dataManuencao;
        }
    }
}
