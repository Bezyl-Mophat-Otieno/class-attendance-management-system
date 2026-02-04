using CAMS.application.Abstractions.Persistence;
using CAMS.domain.ValueValidationTypes;
using CAMS.infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassAttendanceManagementSystem.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    public AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Student student)
    {
        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(StudentId studentId)
    {
        return await _dbContext.Students.FindAsync(studentId);
    }

    public async Task<bool> CheckStudentExistByEmail(EmailAddress studentEmail)
    {
        return await _dbContext.Students.AnyAsync(s => s.Email == studentEmail);
    }
}