using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string path = $"{Server.MapPath("JSON").Replace("Home\\", "")}\\ODwsvAttractions.json";
            StreamReader streamReader=new StreamReader(path);
            FarmAttractions[] farmAttractions = JsonConvert.DeserializeObject<FarmAttractions[]>(streamReader.ReadToEnd());
            HashSet<string> list=new HashSet<string>();
            
            foreach(var i in farmAttractions)
            {
                list.Add(i.City);
            }
            ViewBag.City = list;
            return View(farmAttractions.OrderBy(m => m.City).ThenBy(m => m.Town).ToList());
        }
        [HttpPost]
        public ActionResult Index(string selectCity)
        {
            string path = $"{Server.MapPath("JSON").Replace("Home\\", "")}\\ODwsvAttractions.json";
            StreamReader streamReader = new StreamReader(path);
            FarmAttractions[] farmAttractions = JsonConvert.DeserializeObject<FarmAttractions[]>(streamReader.ReadToEnd());
            HashSet<string> list = new HashSet<string>();

            foreach (var i in farmAttractions)
            {
                list.Add(i.City);
            }
            ViewBag.City = list;
            return View(farmAttractions.OrderBy(m => m.City).ThenBy(m => m.Town).Where(m=>m.City==selectCity).ToList());
        }
        
    }
}