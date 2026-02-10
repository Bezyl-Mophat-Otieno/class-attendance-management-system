using CAMS.application.Courses.Create;
using ClassAttendanceManagementSystem_backend.Dtos.Course;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendanceManagementSystem_backend.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly CreateCourseHandler _handler;

    public CourseController(CreateCourseHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest requestBody, CancellationToken cancellationToken)
    {
        var command = new CreateCourseCommand(
            requestBody.CourseName,
            requestBody.CourseDuration
            );
        var result = await _handler.Handle(command);

        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value.Value }, null) : BadRequest(result.ErrorMessage);

    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }
}