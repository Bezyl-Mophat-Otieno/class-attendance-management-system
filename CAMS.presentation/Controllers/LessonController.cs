using CAMS.application.Abstractions.Persistence;
using CAMS.application.Courses.GetById;
using CAMS.application.Lessons.Create;
using CAMS.application.Units.Create;
using ClassAttendanceManagementSystem_backend.Dtos.Course;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendanceManagementSystem_backend.Controllers;

[ApiController]
[Route("api/lessons")]
public class LessonController : ControllerBase
{
    private readonly CreateLessonHandler _createLessonHandler;
    private readonly GetLessonByIdHandler _getLessonByIdHandler;


    public LessonController(CreateLessonHandler createLessonHandler, GetLessonByIdHandler getLessonByIdHandler)
    {
        _createLessonHandler = createLessonHandler;
        _getLessonByIdHandler = getLessonByIdHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLesson([FromBody] CreateLessonRequest request)
    {
        var command = new CreateLessonCommand(request.UnitID, request.StarDateTime, request.EndDateTime);

        var result = await _createLessonHandler.Handle(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value.Value }, null) : BadRequest(result.ErrorMessage);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetLessonByIdQuery(id);
        var result = await _getLessonByIdHandler.Handle(query);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
    }

}