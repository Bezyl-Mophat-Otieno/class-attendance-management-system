using CAMS.application.Abstractions.Persistence;
using CAMS.domain.Courses;
using CAMS.domain.ValueValidationTypes;
using CAMS.infrastructure.Persistence;
using CAMS.infrastructure.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ClassAttendanceManagementSystem.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private AppDbContext _dbContext;

    public CourseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;

    }
    public async Task AddCourseAsync(Course course)
    {
        try
        {
            await _dbContext.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw EfcoreExceptionTranslator.Translate(e);
        }
    }

    public async Task<Course?> GetByNameAsync(CourseName courseName)
    {
        try
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(c => c.CourseName == courseName);
        }
        catch (Exception e)
        {
            throw EfcoreExceptionTranslator.Translate(e);
        }
    }

    public async Task<Course?> GetCourseByIdAsync(CourseId courseId)
    {
        try
        {
            return await _dbContext.Courses.FindAsync(courseId);
        }
        catch (Exception e)
        {
            throw EfcoreExceptionTranslator.Translate(e);
        }
    }
}