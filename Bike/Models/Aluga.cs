using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace BikeVale.Models
{
    public class Aluga
    {
        public int IdBicicleta { get; set; }
        public int IdHistorico { get; set; }
        public int IdCliente { get; set; }
        public int IdAtendente { get; set; }
        public string Datainicio { get; set; }
        public string DataFim { get; set; }
        public string Cpf { get; set; }
        public Aluga()
        {
        }

        public Aluga(int idBicicleta, int idHistorico, int idCliente, int idAtendente)
        {
            IdBicicleta = idBicicleta;
            IdHistorico = idHistorico;
            IdCliente = idCliente;
            IdAtendente = idAtendente;
        }

    }
}