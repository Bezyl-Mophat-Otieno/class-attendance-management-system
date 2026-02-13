namespace CAMS.application.Lessons.Create;

public sealed record CreateLessonCommand(Guid UnitID, DateTime StartDate, DateTime EndDate);