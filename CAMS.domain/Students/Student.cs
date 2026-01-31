namespace CAMS.domain.ValueValidationTypes;


public class Student
{
    public StudentId StudentId { get; private set; }
    public FullName FullName { get; private set; }
    public EmailAddress Email { get; private set; }
    public CourseId CourseId { get; private set; }
    public int YearOfStudy { get; private set; }

    public Student(StudentId id, FullName fullname, EmailAddress email, CourseId courseId, int yearOfStudy)
    {
        if (yearOfStudy < 1)
        {
            throw new ArgumentException("Year of Study must be atleast 1");
        }

        StudentId = id;
        FullName = fullname;
        Email = email;
        CourseId = courseId;
        YearOfStudy = yearOfStudy;
    }

}