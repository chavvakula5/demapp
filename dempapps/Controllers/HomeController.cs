using dempapps.Models;
using dempapps.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;



namespace dempapps.Controllers
{
    public class HomeController : Controller
    {
       public readonly ILoggerManager _logger;

        public HomeController(ILoggerManager logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Weather()
        {
            var result = ConsumeExternalAPI();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("Weather")]
        public async Task<ActionResult> ConsumeExternalAPI()
        {
            ErrorViewModel errormodel = new ErrorViewModel();
            WeatherModel wm = new WeatherModel();

            string url = "http://api.openweathermap.org/pollution/V1/co/" + "0" + "1" + "2" + "Z.json?" + "appid=APIKey124";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new 
System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                  
                System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
                {

                    var res = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherModel>(res);
                    if (StatusCodes.Status401Unauthorized == 401)
                    {
                        _logger.LogInfo("Unauthorized request.");

                        return View(new WeatherModel { cod = result.cod , message = result.message });
                      
                    }
                    else if (res != null && StatusCodes.Status200OK == 200)
                    {
                       
                        return View(new WeatherModel { cod = wm.cod, message = wm.message });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest);
                    }



                }

            }
        }
    }
}
