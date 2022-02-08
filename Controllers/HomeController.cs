using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using testMVC.Models;
using Microsoft.AspNetCore.Http;

namespace testMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var JsonStr = System.IO.File.ReadAllText("todolist.json");
            var JsonObj = JsonConvert.DeserializeObject<List<ListModel>>(JsonStr);
           ViewBag.json = JsonObj; 
            return View(JsonObj);
        }


     
        //[HttpGet("/About")]
        public IActionResult About(IFormCollection col)
        {
         
            
           ViewData["Message"] ="Hej, detta är skickat med ViewData[Message].";
            ViewBag.text ="Hej, detta är skickat med ViewBag!";

            //Sessionsvariable
           string s = "Text i en sessionsvariabel";
            //hamnar inte hos klienten utan hamnar i servern
        HttpContext.Session.SetString("test", s);

          

            return View();
        }

        public IActionResult Session()
        {
         string? s2 = HttpContext.Session.GetString("test");
       ViewBag.text = s2;

            

            return View();
        }

     
       
        public IActionResult TodoList()
        {
            return View();
        }


        [HttpPost]
        public IActionResult TodoList(ListModel model)
        {
          
         
            
            if (ModelState.IsValid)
            {
                
                ViewBag.text= "This was succesfully added: " +model.name+" "+ model.todo+" "+model.time;
                //Läs in befintlig
                var JsonStr = System.IO.File.ReadAllText("todolist.json");
                //Konverterar till lista
               var JsonObj = JsonConvert.DeserializeObject<List<ListModel>>(JsonStr);

                if(JsonObj != null)
                {

                    JsonObj.Add(model);

                }

             System.IO.File.WriteAllText("todoList.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));
               
                    ModelState.Clear();
         
             
            }


            return View(model);
        }
       



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}