using CAMS.application.Abstractions.Persistence;
using CAMS.domain.Units;
using CAMS.domain.ValueValidationTypes;
using CAMS.infrastructure.Persistence;
using CAMS.infrastructure.Persistence.Exceptions;
using ClassAttendanceManagementSystem.Lessons;
using Microsoft.EntityFrameworkCore;

namespace ClassAttendanceManagementSystem.Persistence.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly AppDbContext _dbContext;

    public LessonRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;

    }
    public async Task AddLessonAsync(Lesson lesson)
    {
        try
        {
            await _dbContext.AddAsync(lesson);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw EfcoreExceptionTranslator.Translate(e);
        }
    }

    public async Task<Lesson?> GetLessonById(LessonId lessonId)
    {
        try
        {
            return await _dbContext.Lessons.FindAsync(lessonId);
        }
        catch (Exception e)
        {
            throw EfcoreExceptionTranslator.Translate(e);

        }

    }
}