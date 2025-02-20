using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FocusOnLife.FrontEnd.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        private readonly HttpClient _httpClient;

        public DashboardController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Ação para renderizar a view
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();  // Retorna a view Dashboard.cshtml
        }

        // Ação para pegar dados do backend
        [HttpGet("api/dashboard")]
        public async Task<IActionResult> GetDashboardData(string location, string status, string searchText)
        {
            var apiUrl = $"https://localhost:7032/api/Condominios?location={location}&status={status}&searchText={searchText}";
            var response = await _httpClient.GetStringAsync(apiUrl);
            var data = JsonConvert.DeserializeObject(response);  // Ajuste para o tipo correto
            return Json(data);
        }
    }
}

