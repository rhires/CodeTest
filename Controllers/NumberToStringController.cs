using System.Collections.Generic;
using codeTest.Models;
using codeTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace codeTest.Controllers
{
    public class NumberToStringController : Controller
    {
        private readonly INumberToStringService _service;

        public NumberToStringController(INumberToStringService service)
        {
            _service = service;
        }

        public IActionResult Index(string startingNumber)
        {
            if (int.TryParse(startingNumber, out int result) || decimal.TryParse(startingNumber, out decimal decimalResult))
            {
                var model = _service.ConvertNumberToString(startingNumber);
                return View(model);
            }
            else 
            {
                return View();
            }
        }
    }
}