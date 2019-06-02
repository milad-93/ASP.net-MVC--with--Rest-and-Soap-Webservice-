using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Sektion1.Models;
using Newtonsoft.Json;

namespace Sektion1.Controllers
{
    public class WebServiceController : Controller
    {
        // GET: WebService
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult SOAP()//kopplad mot webbservice "connected services!" WCF
        {


            try // testar koden ifall webb servicen är startat eller ej
            {
                ServiceReference1.PersonServiceClient klient = new ServiceReference1.PersonServiceClient();
                List<ServiceReference1.PersonerData> Personlista = klient.GetPersonList().ToList();

                //ovjekt som för över alla dat
                return View(Personlista);
            }

            catch( Exception a) // skickar hem dig till home istället för krascha sidan.
            {
                return View("Error", new HandleErrorInfo(a, "WebService", "SOAP"));


                //return RedirectToAction("Error"); // skickar hem dig till home istället för krascha sidan


                // throw new Exception("something went wrong!");  // IFALL WEBBSERVICEN INTE ÄR STARTAD INNAN DU GÅR IN PÅ LÄNKEN SÅ VISAS INDEX
            }


        }
       
       public async Task<ActionResult> REST() // REST WEBBSERVICE!!!! 
            
        {
            try
            {
                List<PersonModell> personInfo = new List<PersonModell>();

                string baseUrl = "http://localhost:57758/personer";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync("Personer");

                    if (Res.IsSuccessStatusCode)
                    {
                        var PersonResponse = Res.Content.ReadAsStringAsync().Result;
                        personInfo = JsonConvert.DeserializeObject<List<PersonModell>>(PersonResponse);

                    }
                }
                return View(personInfo);
            }
            catch (Exception a) // IFALL WEBBSERVICEN INTE ÄR STARTAD INNAN DU GÅR IN PÅ LÄNKEN SÅ VISAS INDEX
            {


               // throw  new Exception("something went wrong");
                
                return View("Error",new HandleErrorInfo(a, "WebService","Rest")); // skickar hem dig till home istället för krascha sidan
            }
        }
    }
}