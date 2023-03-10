using Savage.Data;
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
        public string Email { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public int Telefone { get; set; }
        public int IdEndereco { get; set; }
        public int IdTelefone { get; set; }
        public int Ddd { get; set; }
        public int Tel { get; set; }

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

        public Atendente(int idAtendente, string cpf, string nome, string sobreNome, string rua, int numero, string bairro, string cidade, string cep, int telefone, int idEndereco, int idTelefone, int ddd)
        {
            IdAtendente = idAtendente;
            Cpf = cpf;
            Nome = nome;
            SobreNome = sobreNome;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Telefone = telefone;
            IdEndereco = idEndereco;
            IdTelefone = idTelefone;
            Ddd = ddd;
        }

        public Atendente(int idCliente, string nome, string sobrenome, string cpf,  string rua, int numero, string cidade, string cep, int telefone, int idEndereco, int idTelefone, int ddd, string bairro)
        {
            IdAtendente = idCliente;
            Nome = nome;
            SobreNome = sobrenome;
            Cpf = cpf;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Cep = cep;
            Telefone = telefone;
            IdEndereco = idEndereco;
            IdTelefone = idTelefone;
            Ddd = ddd;
            Bairro = bairro;
        }
    }
}
