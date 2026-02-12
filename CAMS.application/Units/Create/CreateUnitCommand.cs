namespace CAMS.application.Units.Create;

public sealed record CreateUnitCommand(string UnitName, int UnitDuration, Guid CourseId);