using CAMS.domain.ValueValidationTypes;
using ClassAttendanceManagementSystem.Lessons;

namespace CAMS.application.Abstractions.Persistence;

public interface ILessonRepository
{
    public Task AddLessonAsync(Lesson lesson);
    public Task<Lesson?> GetLessonById(LessonId id);


}