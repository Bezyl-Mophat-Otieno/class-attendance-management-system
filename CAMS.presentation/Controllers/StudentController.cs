using CAMS.application.Courses.GetById;
using CAMS.application.Students.Create;
using ClassAttendanceManagementSystem_backend.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendanceManagementSystem_backend.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly CreateStudentHandler _createStudentHandler;

    private readonly GetStudentByIdHandler _getStudentByIdHandler;
    public StudentController(CreateStudentHandler createStudentHandler, GetStudentByIdHandler getStudentByIdHandler)
    {
        _createStudentHandler = createStudentHandler;
        _getStudentByIdHandler = getStudentByIdHandler;
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
        var result = await _createStudentHandler.Handle(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value.Value }, null) : BadRequest(result.ErrorMessage);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetStudentByIdQuery(id);
        var result = await _getStudentByIdHandler.Handle(query);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);

    }
}