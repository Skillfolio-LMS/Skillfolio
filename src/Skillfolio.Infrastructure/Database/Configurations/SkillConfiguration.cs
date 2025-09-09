using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skillfolio.Domain.Skills;

namespace Skillfolio.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(sk => sk.Id);
        
        builder.Property(x => x.SkillName).HasMaxLength(Skill.NameMaxLength).IsRequired();
        builder.Property(x => x.Category).HasMaxLength(Skill.CategoryMaxLength).IsRequired();
    }
}