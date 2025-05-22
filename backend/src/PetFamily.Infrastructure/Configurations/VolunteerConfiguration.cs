using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));

        builder.ComplexProperty(v => v.FullName, fnb =>
        {
            fnb.Property(fn => fn.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(Constants.MAX_NAME_LENGTH);
            
            fnb.Property(fn => fn.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasMaxLength(Constants.MAX_NAME_LENGTH);
            
            fnb.Property(fn => fn.MiddleName)
                .IsRequired()
                .HasColumnName("middle_name")
                .HasMaxLength(Constants.MAX_NAME_LENGTH);
        });
        
        builder.Property(v => v.Email)
            .IsRequired()
            .HasColumnName("email")
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(v => v.Description)
            .IsRequired()
            .HasColumnName("description")
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.Property(ey => ey.ExperienceYears)
            .IsRequired()
            .HasColumnName("experience_years");

        builder.ComplexProperty(v => v.Phone, pb =>
        {
            pb.Property(pn => pn.Number)
                .IsRequired()
                .HasColumnName("phone_number")
                .HasMaxLength(Constants.MAX_PHONE_LENGTH);
        });

        builder.OwnsOne(v => v.SocialNetworks, snb =>
        {
            snb.ToJson("social_networks");

            snb.OwnsMany(s => s.SocialNetwork, slb =>
            {
                slb.Property(sn => sn.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_NAME_LENGTH);

                slb.Property(su => su.Url)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_URL_LENGTH);

            });
        });

        builder.OwnsOne(v => v.Requisites, rb =>
        {
            rb.ToJson("requisites");

            rb.OwnsMany(r => r.Requisite, rlb =>
            {
                rlb.Property(rn => rn.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_NAME_LENGTH);

                rlb.Property(rn => rn.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            });
        });

        builder.HasMany(v => v.OwnedPets)
            .WithOne()
            .HasForeignKey("pet_id")
            .IsRequired(false);

    }
}