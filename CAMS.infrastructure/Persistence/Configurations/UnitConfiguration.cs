using CAMS.domain.Units;
using CAMS.domain.ValueValidationTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassAttendanceManagementSystem.Persistence.Configurations;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units").HasKey(u => u.UnitId);
        builder.Property(u => u.UnitId).HasConversion(
            unitId => unitId.Value,
            value => UnitId.From(value)
            ).ValueGeneratedNever().IsRequired();
        builder.Property(u => u.UnitName).HasConversion(
            unitName => unitName.Value,
            value => UnitName.From(value)
            ).IsRequired();
        builder.Property(u => u.UnitCode).HasConversion(
            unitCode => unitCode.Value,
            value => UnitCode.From(UnitName.From(value))
        ).IsRequired();
        builder.Property(u => u.UnitDuration).HasConversion(
            unitDuration => unitDuration.Value,
            value => UnitDuration.From(value)
        ).IsRequired();
        builder.Property(u => u.CourseId).HasConversion(
            courseid => courseid.Value,
            value => CourseId.From(value)
            ).IsRequired();
        builder.HasIndex(u => u.UnitName).IsUnique();
        builder.HasIndex(u => u.UnitCode).IsUnique();
        builder.HasOne(u => u.Course).WithMany(c => c.Units).HasForeignKey(u => u.CourseId);
    }
}