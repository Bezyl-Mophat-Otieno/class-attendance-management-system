using CAMS.application.Courses.Create;
using CAMS.application.Courses.GetById;
using ClassAttendanceManagementSystem_backend.Dtos.Course;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendanceManagementSystem_backend.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly CreateCourseHandler _createCourseHandler;

    private readonly GetCourseByIdHandler _courseByIdHandler;

    public CourseController(CreateCourseHandler createCourseHandler, GetCourseByIdHandler courseByIdHandler)
    {
        _createCourseHandler = createCourseHandler;
        _courseByIdHandler = courseByIdHandler;
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
        var result = await _createCourseHandler.Handle(command);

        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value.Value }, null) : BadRequest(result.ErrorMessage);

    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCourseByIdQuery(id);
        var result = await _courseByIdHandler.Handle(query);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
    }
}