using System.ComponentModel.DataAnnotations;

namespace BikeVale.Models
{
    public class Bicicleta
    {
        public int IdBicicleta { get; set; }

        //[Required(ErrorMessage = "O modelo é obrigatório.")]
        public string Modelo { get; set; }

        //[Required(ErrorMessage = "O modalidade é obrigatório.")]
        public string Modalidade { get; set; }

        //[Required(ErrorMessage = "O QtdMarchas é obrigatório.")]
        public int QtdMarchas{ get; set; }

        ///[Required(ErrorMessage = "O StatusEmprestimo é obrigatório.")]
        public int StatusEmprestimo { get; set; }
        public int result { get; set; }



        public Bicicleta()
        {
        }
        public Bicicleta(int idBicicleta)
        {
            IdBicicleta = idBicicleta;
        }
        public Bicicleta(int idBicicleta, string modelo, string modalidade, int qtdMarchas, int statusEmprestimo)
        {
            IdBicicleta = idBicicleta;
            Modelo = modelo;
            Modalidade = modalidade;
            QtdMarchas = qtdMarchas;
            StatusEmprestimo = statusEmprestimo;
        }
    }
}
