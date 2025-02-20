using FocusOnLife.Application.Interfaces.Services;
using FocusOnLife.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FocusOnLife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominiosController : ControllerBase
    {
        private readonly ICondominioService _condominioService;

        public CondominiosController(ICondominioService condominioService)
        {
            _condominioService = condominioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCondominios()
        {
            var condominios = await _condominioService.GetCondominiosAsync();
            return Ok(condominios);
        }
    }
}
