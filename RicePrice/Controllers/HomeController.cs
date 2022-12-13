using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RicePrice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Globalization;

namespace RicePrice.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHostingEnvironment _HostEnviroment;
		public static string GetDate(string qDate)
		{
			DateTime dateTime = DateTime.Parse(qDate);
			CultureInfo culture = new CultureInfo("zh-TW");
			culture.DateTimeFormat.Calendar = new TaiwanCalendar();
			return (dateTime.ToString("yyy.M.d", culture));
		}
		public HomeController(ILogger<HomeController> logger,IHostingEnvironment HostEnviroment)
		{
			_logger = logger;
			_HostEnviroment = HostEnviroment;

		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(string qDate)
		{
			if (qDate == null)
			{
				ViewBag.Error = "請選擇日期";
				return View();
			}
			string twDate = GetDate(qDate);
			Debug.WriteLine(twDate);
			string url = "https://data.coa.gov.tw/Service/OpenData/FromM/RicepriceData.aspx";
			HttpClient httpClient = new HttpClient();
			httpClient.MaxResponseContentBufferSize = Int32.MaxValue;
			var response = await httpClient.GetStringAsync(url);
			string path = $"{Path.Combine(_HostEnviroment.WebRootPath, "Data")}\\RicePrice.json";
			//FileInfo fileInfo = new FileInfo(path);
			StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.UTF8);
			streamWriter.WriteLine(response);
			streamWriter.Close();
			StreamReader streamReader = new StreamReader(path);
			var jsonData = JsonConvert.DeserializeObject<List<RicePriceModel>>(streamReader.ReadToEnd());

			ViewBag.jsonQueryName = from r in jsonData
									where r.pt_date_day == twDate
									select r.Name;

			ViewBag.jsonQueryPrice= from r in jsonData
									where r.pt_date_day == twDate
									select r.pt_1japt;
			streamReader.Close();
			ViewBag.Status = StatusCode(200);
			return View();
		}
	}
}
