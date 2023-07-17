using Microsoft.AspNetCore.Mvc;
using WebApplicationtest1.Models;
using WebApplicationtest1.Services;
using WebApplicationtest1.ViewModels;
using System.Web.Http.Cors;
namespace WebApplicationtest1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FundController : ControllerBase
    {
        private readonly IFundService _fundService;

        public FundController(IFundService fundService)
        {
            _fundService = fundService ?? throw new ArgumentNullException(nameof(fundService));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFunds()
        {
            IEnumerable<Fund> funds = await _fundService.GetAllFunds();
            return Ok(funds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundById(int id)
        {
            Fund fund = await _fundService.GetFundById(id);

            if (fund == null)
            {
                return NotFound();
            }

            return Ok(fund);
        }
        [HttpGet("trends")]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IActionResult> GetAllFundTrendByDate(DateTime date)
        {
            var fundTrendDtos = await _fundService.GetAllFundTrendByDate(date);
            return Ok(fundTrendDtos);

        }
        [HttpGet("cure")]
        public async Task<IActionResult> GetAllFundCure()
        {
            var fundCureDtos = await _fundService.GetAllFundCure();
            return Ok(fundCureDtos);
        }

    }
}
