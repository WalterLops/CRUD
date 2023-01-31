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
        public IActionResult Detalhes(Aluga aluga)
        {
            //Bicicleta  bicicleta = new Bicicleta(bike.IdBicicleta);
            //return View("Reserva");
            return View("detalhes-reserva", aluga);
        }

        // GET: Alugar1Controller/Details/5
        /*public ActionResult Details(int id)
        {
            return View("Reserva");
        }*/

        // GET: Alugar1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alugar1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Alugar1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alugar1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Alugar1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alugar1Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
