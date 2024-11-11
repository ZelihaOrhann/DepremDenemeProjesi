using DepremDeneme.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DepremDeneme.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class HomeController : Controller
{
	private readonly HttpClient _httpClient;

	public HomeController()
	{
		_httpClient = new HttpClient();
	}

	// Türkiye genelinde son 24 saatteki depremleri çeker
	public async Task<IActionResult> Index()
	{
		string apiUrl = "https://api.orhanaydogdu.com.tr/deprem/kandilli/live"; // API URL

		var response = await _httpClient.GetStringAsync(apiUrl);
		var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

		return View(apiResponse.Data);
	}
}

// API'den dönen JSON yapısına uygun model
public class ApiResponse
{
	public List<Deprem> Data { get; set; }
}
