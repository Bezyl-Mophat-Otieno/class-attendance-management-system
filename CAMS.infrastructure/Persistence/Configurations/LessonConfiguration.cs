using CAMS.domain.ValueValidationTypes;
using ClassAttendanceManagementSystem.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassAttendanceManagementSystem.Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons").HasKey(l => l.LessonId);
        builder.Property(l => l.LessonId).HasConversion(
            lesson => lesson.Value,
            value => LessonId.From(value)
            ).ValueGeneratedNever().IsRequired();
        builder.Property(l => l.UnitId).HasConversion(
            unitId => unitId.Value,
            value => UnitId.From(value)
        ).IsRequired();
        builder.Property(l => l.Duration).HasConversion(
            duration => duration.Value,
            value => LessonDuration.FromTimespan(value)
        ).ValueGeneratedNever().IsRequired();
        builder.Property(l => l.StarDateTime).IsRequired();
        builder.Property(l => l.EndDateTime).IsRequired();
    }
}