using CAMS.domain.ValueValidationTypes;

namespace CAMS.domain.Units;

public class Unit
{
    public UnitId UnitId { get; private set; }
    public UnitName UnitName { get; private set; }
    public UnitCode UnitCode { get; private set; }
    public UnitDuration UnitDuration { get; private set; }

    private Unit(UnitId id, UnitName name, UnitDuration duration)
    {
        UnitId = id;
        UnitName = name;
        UnitCode = UnitCode.From(name);
        UnitDuration = duration;
    }

    public Unit Create(UnitName name, UnitDuration duration)
    {
        return new Unit(UnitId.New(), name, duration);
    }

    public void Rename(UnitName name)
    {
        UnitName = name;
        UnitCode = UnitCode.From(name);
    }
}