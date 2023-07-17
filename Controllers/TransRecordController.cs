using Microsoft.AspNetCore.Mvc;
using WebApplicationtest1.Services;

namespace WebApplicationtest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransRecordController:ControllerBase
    {
        private readonly ITransRecordService _transRecordService;

        public TransRecordController(ITransRecordService transRecordService)
        {
            _transRecordService = transRecordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransRecordByFundNameAndDate(string fundName, DateTime date)
        {
            var transRecordDtos = await _transRecordService.GetTransRecordByFundNameAndDateAsync(fundName, date);
            return Ok(transRecordDtos);
        }

    }
}
