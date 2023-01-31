using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeVale.Data;
using BikeVale.Models;

namespace BikeVale.Controllers {
    public class SobreController : Controller {
        private readonly Contexto _context;

        public SobreController(Contexto context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            return View();
        }

    }
}
