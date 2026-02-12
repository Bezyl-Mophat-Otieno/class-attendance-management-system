using CAMS.domain.Courses;
using CAMS.domain.ValueValidationTypes;

namespace CAMS.domain.Units;

public class Unit
{
    public UnitId UnitId { get; private set; }
    public UnitName UnitName { get; private set; }
    public UnitCode UnitCode { get; private set; }
    public UnitDuration UnitDuration { get; private set; }

    public CourseId CourseId { get; private set; }

    public Course Course { get; private set; } = null; // navigation property


    private Unit(UnitId unitId, UnitName unitName, UnitDuration unitDuration, CourseId courseId)
    {
        UnitId = unitId;
        UnitName = unitName;
        UnitCode = UnitCode.From(unitName);
        UnitDuration = unitDuration;
        CourseId = courseId;
    }

    public static Unit Create(UnitName name, UnitDuration duration, CourseId courseId)
    {
        return new Unit(UnitId.New(), name, duration, courseId);
    }

    public void Rename(UnitName name)
    {
        UnitName = name;
        UnitCode = UnitCode.From(name);
    }
}