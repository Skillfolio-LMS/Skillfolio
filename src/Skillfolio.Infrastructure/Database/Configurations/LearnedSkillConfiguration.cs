using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skillfolio.Domain.LearnedSkills;

namespace Skillfolio.Infrastructure.Database.Configurations;

public class LearnedSkillConfiguration : IEntityTypeConfiguration<LearnedSkill>
{
    public void Configure(EntityTypeBuilder<LearnedSkill> builder)
    {
        builder.ToTable("learnedskills");

        builder.HasKey(x => x.Id);
        
        builder.HasOne(ls => ls.Skill)
            .WithMany()              
            .HasForeignKey(ls => ls.SkillId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.Property(x => x.ProficiencyLevel).IsRequired();
    }
}
