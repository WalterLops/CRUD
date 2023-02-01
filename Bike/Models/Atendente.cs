﻿using System.ComponentModel.DataAnnotations;
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
        public string IdEndereco { get; set; }
        public string IdTelefone { get; set; }
        public int Ddd { get; set; }
        public int Tel { get; set; }

        public Atendente()
        {
        }
    }
}