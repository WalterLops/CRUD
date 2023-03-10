using BikeVale.Data;
using BikeVale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Savage.Data;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bike.Controllers
{
    public class AtendenteController : Controller
    {
        private readonly Contexto _context;

        public ActionResult Index()
        {
            return View();
        }
        /*
         * INICIO BICICLETA
         */
        [HttpPost]
        public IActionResult BicicletasCadastradas()
        {
            return View("bikes-disponiveis-alugadas");
        }

        [HttpGet]
        public IActionResult cadastroBicicleta()
        {

            return View("cadastroBicicleta");
        }

        [HttpPost]
        public IActionResult BicicletasDisponiveis()
        {
            return View("bikes-disponiveis-alugadas");
        }

        [HttpPost]
        public IActionResult HistoricoBikes()
        {
            return View("historicoAdim");
        }

        [HttpPost]
        public IActionResult BicicletaManutecao()
        {
            return View("bikes-em-munutencao"); 
        }

        [HttpPost]
        public async Task<IActionResult> cadastroBicicletaPost(Bicicleta bike)
        {
            
            if (bike.Modelo != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand($"INSERT INTO bicicleta (Id_bicicleta, Modelo, Modalidade, Qtd_marchas, Status_emprestimo) VALUES ({bike.IdBicicleta},'{bike.Modelo}', '{bike.Modalidade}', {bike.QtdMarchas}, {bike.StatusEmprestimo});", connection))
                    {
                        bike.result = command.ExecuteNonQuery();
                    }
                }
            }
            return View("cadastroBicicleta", bike);
        }

        [HttpPost]
        public IActionResult ConcluirManutencao()
        {
            return View("bikes-em-munutencao"); 
        }
        [HttpPost]
        public IActionResult DeleteBicicleta(Bicicleta bicicleta)
        {
            var idCliente = AtendenteController.DecobreIdCliente(bicicleta.IdBicicleta);
            var query = "";

            var query1 = $"DELETE FROM `bancotp`.`bicicleta` WHERE(`Id_bicicleta` = {bicicleta.IdBicicleta});";

            var query2 = $"DELETE FROM `bancotp`.`aluga` WHERE(`Id_cliente` = {idCliente}) and(`Id_bicicleta` = {bicicleta.IdBicicleta});" +
                         $"DELETE FROM `bancotp`.`bicicleta` WHERE(`Id_bicicleta` = {bicicleta.IdBicicleta});";


            query = bicicleta.StatusEmprestimo == 1 ? query1 : query2;

            if (bicicleta.IdBicicleta != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteNonQuery();
                    }
                }
            }
            return View("bikes-disponiveis-alugadas");
        }

        [HttpPost]
        public IActionResult AtualizarBicicleta(Bicicleta Bicicleta)
        {
            // Implementar delete
            return View("bikes-disponiveis-alugadas");
        }

        /*
         * ----------------FIM BICICLETA------------------------
         */


        /*
         * INICIO CLIENTE
         */
        [HttpPost]
        public IActionResult CadastroCliente()
        {
            return View("ClientesCadastrados");
        }


        [HttpPost]
        public IActionResult cadastroClientePost(Cliente cliente)
        {
            var result = 0;
            var query = $"START TRANSACTION;"+$"INSERT INTO endereco (Id_endereco, Numero, Rua, bairro, Cidade, cep) VALUES ({cliente.IdEndereco}, '{cliente.Numero}', '{cliente.Rua}', '{cliente.Bairro}', '{cliente.Cidade}', '{cliente.Cep}');"
                      + $"INSERT INTO telefone (Id_tel, DDD, Telefone) VALUES ( {cliente.IdTelefone}, {cliente.Ddd}, {cliente.Telefone});"
                      + $"INSERT INTO cliente (Id_cliente, Cpf, Nome, Sobrenome, Id_endereco,Id_tel,Email) VALUES ({cliente.IdCliente}, '{cliente.Cpf}', '{cliente.Nome}', '{cliente.Sobrenome}', {cliente.IdEndereco}, {cliente.IdTelefone}, '{cliente.Email}');"+"COMMIT;";

            if (cliente.Nome != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        result = command.ExecuteNonQuery();
                    }
                }
            }
            return View("cadastroCliente");
        }


        [HttpPost]
        public IActionResult AtualizarCliente(Cliente cliente)
        {
            return View("AtualizarCliente");
        }
        [HttpPost]
        public IActionResult AtualizarClientePost(Cliente cliente)
        {
            var result = 0;
            var query = $"START TRANSACTION;"+$"UPDATE `bancotp`.`endereco` SET `Numero` = '{cliente.Numero}', `Rua` = '{cliente.Rua}', `Cidade` = '{cliente.Rua}', `cep` = '{cliente.Cep}', `Bairro` = '{cliente.Bairro}'  WHERE (`Id_endereco` = '{cliente.IdEndereco}');"
                      + $" UPDATE `bancotp`.`telefone` SET `DDD` = '{cliente.Ddd}', `Telefone` = '{cliente.Telefone}' WHERE (`Id_tel` = '{cliente.IdTelefone}');"
                      + $" UPDATE `bancotp`.`cliente` SET  `Cpf` = '{cliente.Cpf}', `Nome` = '{cliente.Nome}', `Sobrenome` = '{cliente.Sobrenome}', `Email` = '{cliente.Email}' WHERE (`Id_cliente` = '{cliente.IdCliente}');"+"COMMIT;";

            if (cliente.Nome != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        result = command.ExecuteNonQuery();
                    }
                }
            }
            return View("AtualizarCliente");
        }


        [HttpPost]
        public IActionResult DeleteCliente(Cliente cliente)
        {
            var query = $"START TRANSACTION;"+ $"DELETE FROM `bancotp`.`cliente` WHERE(`Id_cliente` = {cliente.IdCliente});"
                      + $"DELETE FROM `bancotp`.`telefone` WHERE(`Id_tel` = {cliente.IdTelefone});"
                      + $"DELETE FROM `bancotp`.`endereco` WHERE(`Id_endereco` = {cliente.IdEndereco})" +"COMMIT;";

            if (cliente.IdCliente != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteNonQuery();
                    }
                }
            }
            return View("ClientesCadastrados");
        }

        /*
         * ------------------FIM CLIENTE----------------------------
         */
        
        /*
         * INICIO ATENDDENTE
         */
        [HttpPost]
        public  IActionResult CadastroAtendente(Atendente atendente)
        {
            var query = $"START TRANSACTION;"+
            $"INSERT INTO endereco (Id_endereco, Numero, Rua, bairro, Cidade, cep) VALUES ({atendente.IdEndereco}, '{atendente.Numero}', '{atendente.Rua}', '{atendente.Bairro}', '{atendente.Cidade}', '{atendente.Cep}');"
                        + $"INSERT INTO telefone (Id_tel, DDD, Telefone) VALUES ( {atendente.IdTelefone}, {atendente.Ddd}, {atendente.Telefone});"
                        + $"INSERT INTO atendente (Id_atendente, Cpf, Nome, Sobrenome, Id_endereco, Id_tel) VALUES ({atendente.IdAtendente},'{atendente.Cpf}', '{atendente.Nome}', '{atendente.SobreNome}', {atendente.IdEndereco}, {atendente.IdTelefone});"
                        +"COMMIT;";

            if (atendente.Nome != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteNonQuery();
                    }
                }

            }
            return View("cadastroFuncionario");
        }

        [HttpPost]
        public IActionResult AtendentesCadastrados(Cliente cliente)
        {
            return View("AtendentesCadastrados");
        }

        [HttpPost]
        public IActionResult AtualizarAtendente(Atendente atendente)
        {
            return View("AtualizarFuncionario");
        }

        [HttpPost]
        public IActionResult AtualizarAtendentePost(Atendente atendente)
        {
            var query = $"START TRANSACTION;"+
            $"UPDATE `bancotp`.`endereco` SET `Numero` = '{atendente.Numero}', `Rua` = '{atendente.Rua}', `Cidade` = '{atendente.Rua}', `cep` = '{atendente.Cep}', `Bairro` = '{atendente.Bairro}'  WHERE (`Id_endereco` = '{atendente.IdEndereco}');"
                     + $" UPDATE `bancotp`.`telefone` SET `DDD` = '{atendente.Ddd}', `Telefone` = '{atendente.Telefone}' WHERE (`Id_tel` = '{atendente.IdTelefone}');"
                     + $" UPDATE `bancotp`.`atendente` SET  `Cpf` = '{atendente.Cpf}', `Nome` = '{atendente.Nome}', `Sobrenome` = '{atendente.SobreNome}' WHERE (`Id_atendente` = '{atendente.IdAtendente}');" +"COMMIT;";

            if (atendente.Nome != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteNonQuery();
                    }
                }
            }
            return View("AtualizarFuncionario");
        }


        [HttpPost]
        public IActionResult DeleteAtendente(Atendente atendente)
        {
            var query = $"START TRANSACTION;"+ $"DELETE FROM `bancotp`.`atendente` WHERE(`Id_atendente` = {atendente.IdAtendente});"
                      + $"DELETE FROM `bancotp`.`telefone` WHERE(`Id_tel` = {atendente.IdTelefone});"
                      + $"DELETE FROM `bancotp`.`endereco` WHERE(`Id_endereco` = {atendente.IdEndereco});"+"COMMIT;";

            if (atendente.IdAtendente != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteNonQuery();
                    }
                }
            }
            return View("AtendentesCadastrados");
        }


        [HttpPost]
        public IActionResult AlugarBicicleta(Bicicleta Bicicleta)
        {
            // 
            return View("bikes-disponiveis-alugadas");
        }

        [HttpPost]
        public IActionResult ManutecaoBicicleta(Bicicleta Bicicleta)
        {
            // 
            return View("bikes-em-munutencao");
        }

        [HttpPost]
        public IActionResult DevolverBicicleta(Bicicleta bicicleta)
        {
            var query = $"UPDATE `bancotp`.`bicicleta` SET `Status_emprestimo` = '0' WHERE(`Id_bicicleta` = {bicicleta.IdBicicleta});";
            if (bicicleta.IdBicicleta != null)
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteNonQuery();
                    }
                }
            }
            return View("bikes-em-munutencao");
        }


        /*
         * -----------------FIM ATENDENTE----------------------
         */
        public static int DecobreIdCliente(int idBike)
        {
            var id = 0;
            using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT aluga.Id_cliente FROM aluga Where  aluga.Id_bicicleta ={idBike}", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt32(reader["Id_cliente"]);
                        }
                    }
                }
            }
            return id;
        }
    }

}
