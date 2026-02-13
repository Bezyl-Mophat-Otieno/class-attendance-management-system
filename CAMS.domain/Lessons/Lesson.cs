using CAMS.domain.ValueValidationTypes;

namespace ClassAttendanceManagementSystem.Lessons;

public class Lesson
{
    public LessonId LessonId { get; private set; }
    public UnitId UnitId { get; private set; }
    public DateTime StarDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    public LessonDuration Duration { get; private set; }



    private Lesson(LessonId lessonId, UnitId unitId, DateTime starDateTime, DateTime endDateTime)
    {
        LessonId = lessonId;
        UnitId = unitId;
        StarDateTime = starDateTime;
        EndDateTime = endDateTime;
        Duration = LessonDuration.From(starDateTime, endDateTime);
    }

    public static Lesson Create(UnitId unitId, DateTime start, DateTime end)
    {
        return new Lesson(LessonId.New(), unitId, start, end);
    }
}