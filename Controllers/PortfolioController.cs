using Microsoft.AspNetCore.Mvc;
using WebApplicationtest1.Models;
using WebApplicationtest1.Services;

namespace WebApplicationtest1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController:ControllerBase
    {
        private readonly IInvestmentPortfolioService _portfolioService;

        public PortfolioController(IInvestmentPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPortfolioByFundNameAndTime(string fundName, DateTime date)
        {
            var portfolioDtos = await _portfolioService.GetPortfolioByFundNameAndTime(fundName, date);
            return Ok(portfolioDtos);
        }

    }
}
