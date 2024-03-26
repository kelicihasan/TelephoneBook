using Microsoft.AspNetCore.Mvc;
using Report.Application.Services.Abstract;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IReportDetailService _reportDetailService;
        public ReportController(IReportService reportService, 
            IReportDetailService reportDetailService)
        {
            _reportService = reportService;
            _reportDetailService = reportDetailService;
        }

        /// <summary>
        /// Add a new Report
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var data = await _reportService.Create();
            if (data == null)
                return NotFound(data);
            return Ok(data);
        }

        /// <summary>
        /// Get All Report
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _reportService.GetAll();

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        /// <summary>
        /// Get Report By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _reportService.GetById(id);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        /// <summary>
        /// Get All Report Detail
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-report-detail")]
        public async Task<IActionResult> GetAllDetail()
        {
            var data = await _reportDetailService.GetAll();

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        /// <summary>
        /// Get Report Detail By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/get-report-detail")]
        public async Task<IActionResult> GetDetailById(Guid id)
        {
            var data = await _reportDetailService.GetAllById(id);

            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
