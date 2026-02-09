using CAMS.application.Students.Create;
using ClassAttendanceManagementSystem_backend.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendanceManagementSystem_backend.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly CreateStudentHandler _handler;
    public StudentController(CreateStudentHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest requestBody, CancellationToken cancellationToken)
    {
        var command = new CreateStudentCommand(
            requestBody.FirstName,
            requestBody.LastName,
            requestBody.Email,
            requestBody.CourseId,
            requestBody.YearOfStudy
            );
        var result = await _handler.Handle(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value }, null) : BadRequest(result.ErrorMessage);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }
}