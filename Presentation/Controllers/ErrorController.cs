using Application.UseCases.ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        //private readonly AssignErrorToEmployee _assignErrorToEmployee;

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
    }

    public class AssignErrorRequest
    {
        public int ErrorId { get; set; }
        public int EmployeeId { get; set; }
    }
}
