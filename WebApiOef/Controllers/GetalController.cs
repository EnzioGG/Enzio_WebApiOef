using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Reflection;

namespace WebApiOef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetalController : ControllerBase
    {
        string filenumber = @"C:\Users\enzio\OneDrive\School software developer\programmeren\AspNET\Enzio_WebApiOef\WebApiOef\getal.txt";
        
        [HttpGet]
        public ActionResult<int> GetNumber()
        {

            if (System.IO.File.Exists(filenumber))
            {
                int number = Convert.ToInt32(System.IO.File.ReadAllText(filenumber));
                return number;
            }
            return NotFound();
        }
        [HttpPost("nieuw getal")]
        public ActionResult<int> CreateNewNumber(Getal newGetal)
        {
            string number = Convert.ToString(newGetal.nr);
            System.IO.File.WriteAllText(filenumber, number);

            return Ok();

        }
        [HttpPost("Random getal")]
        public ActionResult<int> CreateRandomNumber()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Random rnd = new Random();
            int index = rnd.Next(numbers.Length);
            System.IO.File.WriteAllText(filenumber, Convert.ToString(numbers[index]));
            return Ok();
        }
    }
    public class Getal
    {
        public int nr { get; set; }
    }

}
