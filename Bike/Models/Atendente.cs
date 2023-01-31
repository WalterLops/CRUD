using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeVale.Models
{
    public class Atendente
    {
        public int IdAtendente { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public int IdEndereco { get; set; }
        public int IdTelefone { get; set; }

        public Atendente()
        {
        }

        public Atendente(int idAtendente, string cpf, string nome, string sobreNome, int idEndereco, int idTelefone)
        {
            IdAtendente = idAtendente;
            Cpf = cpf;
            Nome = nome;
            SobreNome = sobreNome;
            IdEndereco = idEndereco;
            IdTelefone = idTelefone;
        }
    }
}
