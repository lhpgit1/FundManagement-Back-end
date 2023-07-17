using Microsoft.AspNetCore.Mvc;
using WebApplicationtest1.Models;
using WebApplicationtest1.Services;

namespace WebApplicationtest1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController:ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService ?? throw new ArgumentNullException(nameof(stockService));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _stockService.GetAllStocks();
            return Ok(stocks);
        }

        [HttpGet("{stockId}")]
        public async Task<IActionResult> GetStockById(int stockId)
        {
            var stock = await _stockService.GetStockById(stockId);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] Stock stock)
        {
            await _stockService.AddStock(stock);
            return Ok();
        }

        [HttpDelete("{stockId}")]
        public async Task<IActionResult> DeleteStock(int stockId)
        {
            await _stockService.DeleteStock(stockId);
            return Ok();
        }

    }
   
}
