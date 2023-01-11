using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClientApp.Models;
using DataBaseEntities;
using ClientApp.Repositories;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IClientRepositories<Item> _clientRepositories;

        public HomeController(ILogger<HomeController> logger, IClientRepositories<Item> clientRepository)
        {
            _logger = logger;
            _clientRepositories = clientRepository;

        }

        public async Task<IActionResult> Index()
        {

            return View(new ItemViewModel { Items = await _clientRepositories.GetAll() });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}