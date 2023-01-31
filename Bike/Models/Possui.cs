using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace BikeVale.Models
{
    public class Possui
    {
        public int IdManutencao { get; set; }
        public int IdBicicleta { get; set; }
        public int IdAtendente { get; set; }
    }
}
