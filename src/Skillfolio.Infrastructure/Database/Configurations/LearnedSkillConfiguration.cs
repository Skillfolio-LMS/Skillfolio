using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skillfolio.Domain.LearnedSkills;

namespace Skillfolio.Infrastructure.Database.Configurations;

public class LearnedSkillConfiguration : IEntityTypeConfiguration<LearnedSkill>
{
    public void Configure(EntityTypeBuilder<LearnedSkill> builder)
    {
        builder.ToTable("learnedskills");

        builder.HasOne(x => x.Skill)
            .WithMany(s => s.LearnedSkills)
            .HasForeignKey(x => x.SkillId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ProficiencyLevel).IsRequired();
    }
}
