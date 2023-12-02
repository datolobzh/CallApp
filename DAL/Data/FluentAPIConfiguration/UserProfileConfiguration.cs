using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.FluentAPIConfiguration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            // Primary Key
            builder.HasKey(up => up.Id);

            // Foreign Key
            builder.HasOne(up => up.User)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<UserProfile>(up => up.UserId)
                .IsRequired();

            // Other configurations
            builder.Property(up => up.FirstName)
                .IsRequired();

            builder.Property(up => up.LastName)
                .IsRequired();

            builder.Property(up => up.PersonalNumber)
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
