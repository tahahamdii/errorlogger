using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        //private readonly AssignErrorToEmployee _assignErrorToEmployee;
        private readonly GetFilteredErrors _getFilteredErrors;

        //public ErrorController(AssignErrorToEmployee assignErrorToEmployee)
        //{
        //    _assignErrorToEmployee = assignErrorToEmployee;
        //}

        [HttpPost("assign")]
        public async Task<IActionResult> AssignError([FromBody] AssignErrorRequest request)
        {
            //await _assignErrorToEmployee.ExecuteAsync(request.ErrorId, request.EmployeeId);
            return Ok("Error assigned successfully.");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetFilteredErrors(
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        [FromQuery] string severity,
        [FromQuery] int? assignedEmployeeId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
        {
            var result = await _getFilteredErrors.ExecuteAsync(
                (DateTime)startDate, (DateTime)endDate, severity, assignedEmployeeId, page, pageSize);

            return Ok(result);
        }
    }


    public class AssignErrorRequest
    {
        public int ErrorId { get; set; }
        public int EmployeeId { get; set; }
    }
}
