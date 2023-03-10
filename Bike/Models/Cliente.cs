using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace BikeVale.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
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


        public Cliente()
        {
        }

        public Cliente(int idCliente, string nome, string sobrenome, string cpf, string email, string rua, int numero, string cidade, string cep, int telefone)
        {
            IdCliente = idCliente;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Email = email;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Cep = cep;
            Telefone = telefone;
        }

        public Cliente(int idCliente, string nome, string sobrenome, string cpf, string email, string rua, int numero, string cidade, string cep, int telefone, int idEndereco, int idTelefone, int ddd)
        {
            IdCliente = idCliente;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Email = email;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Cep = cep;
            Telefone = telefone;
            IdEndereco = idEndereco;
            IdTelefone = idTelefone;
            Ddd = ddd;
        }

        public Cliente(int idCliente, string nome, string sobrenome, string cpf, string email, string rua, int numero, string cidade, string cep, int telefone, int idEndereco, int idTelefone)
        {
            IdCliente = idCliente;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Email = email;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Cep = cep;
            Telefone = telefone;
            IdEndereco = idEndereco;
            IdTelefone = idTelefone;
        }

    }

}
