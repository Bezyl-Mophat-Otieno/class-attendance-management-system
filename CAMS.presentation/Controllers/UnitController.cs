using CAMS.application.Abstractions.Persistence;
using CAMS.application.Courses.GetById;
using CAMS.application.Units.Create;
using ClassAttendanceManagementSystem_backend.Dtos.Course;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendanceManagementSystem_backend.Controllers;

[ApiController]
[Route("api/units")]
public class UnitController : ControllerBase
{
    private readonly CreateUnitHandler _createUnitHandler;
    private readonly GetUnitByIdHandler _getUnitByIdHandler;


    public UnitController(CreateUnitHandler createUnitHandler, GetUnitByIdHandler getUnitByIdHandler)
    {
        _createUnitHandler = createUnitHandler;
        _getUnitByIdHandler = getUnitByIdHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUnit([FromBody] CreateUnitRequest request)
    {
        var command = new CreateUnitCommand(request.unitName, request.unitDuration, request.courseId);

        var result = await _createUnitHandler.Handle(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value.Value }, null) : BadRequest(result.ErrorMessage);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetUnitByIdQuery(id);
        var result = await _getUnitByIdHandler.Handle(query);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
    }

}