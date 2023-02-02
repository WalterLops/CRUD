using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeVale.Data;
using BikeVale.Models;
using MySqlConnector;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bike.Controllers
{
    public class AlugarController : Controller
    {
        private readonly Contexto _context;
        protected static MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp");

        // GET: Alugar1Controller
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmReserva(Bicicleta bike)
        {
            var id = bike.IdBicicleta;

            //return View("Reserva");
            return View("ConfirmaReserva");
        }

        [HttpPost]
        public IActionResult ConfirmReserva1(Bicicleta bike)
        {
            Aluga aluga = new Aluga(){IdBicicleta = bike.IdBicicleta};
            return View("ConfirmaReserva", aluga);
        }

        [HttpPost]
        public IActionResult AlugarBicicleta(Aluga aluga)
        {
            var id = AlugarController.DecobreId(aluga.Cpf);
            if (aluga.IdBicicleta != null)
            {
                var query = $"START TRANSACTION;" +
                            $"call sp_atualizastatusbike({aluga.IdBicicleta}); " +
                           $"INSERT INTO `bancotp`.`aluga` (`Id_bicicleta`, `Id_cliente`) VALUES ({aluga.IdBicicleta}, {id});"
                           + "COMMIT;";
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

        public static int DecobreId(string cpf)
        {
            var id = 0; 
            using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=teste@;password=123456;database=bancotp"))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT cliente.Id_cliente from cliente where cliente.Cpf = '{cpf}';", connection))
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
