using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(Constants.MAX_NAME_LENGTH);

        builder.ComplexProperty(p => p.Species, sb =>
        {
            sb.Property(p => p.BreedId)
                .IsRequired()
                .HasColumnName("breed_id")
                .HasConversion(
                    id => id.Value,
                    value => BreedId.Create(value));
            
            sb.Property(p => p.SpeciesId)
                .IsRequired()
                .HasColumnName("species_id")
                .HasConversion(
                    id => id.Value,
                    value => SpeciesId.Create(value));
        });

        builder.Property(p => p.AllDescription)
            .IsRequired()
            .HasColumnName("all_description")
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        
        builder.Property(p => p.Coloring)
            .IsRequired()
            .HasColumnName("coloring")
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(p => p.HealthPet)
            .IsRequired()
            .HasColumnName("health_pet")
            .HasMaxLength(Constants.MAX_MEDIUM_TEXT_LENGTH);

        builder.ComplexProperty(p => p.AddressPet, apb =>
        {
            apb.Property(a => a.Country)
                .IsRequired()
                .HasColumnName("country")
                .HasMaxLength(Constants.MAX_MEDIUM_TEXT_LENGTH);
            
            apb.Property(a => a.City)
                .IsRequired()
                .HasColumnName("city")
                .HasMaxLength(Constants.MAX_MEDIUM_TEXT_LENGTH);
            
            apb.Property(a => a.Street)
                .IsRequired()
                .HasColumnName("street")
                .HasMaxLength(Constants.MAX_MEDIUM_TEXT_LENGTH);
            
            apb.Property(a => a.House)
                .IsRequired()
                .HasColumnName("house")
                .HasMaxLength(Constants.MAX_MEDIUM_TEXT_LENGTH);
        });

        builder.Property(p => p.Weight)
            .IsRequired()
            .HasColumnName("weight");
        
        builder.Property(p => p.Height)
            .IsRequired()
            .HasColumnName("height");

        builder.ComplexProperty(p => p.Phone, pnb =>
        {
            pnb.Property(pn => pn.Number)
                .IsRequired()
                .HasColumnName("number")
                .HasMaxLength(Constants.MAX_NAME_LENGTH);
        });
        
        builder.Property(p => p.NeuteredOrNot)
            .IsRequired()
            .HasColumnName("neutered_or_not");
        
        builder.Property(p=>p.BirthDate)
            .IsRequired()
            .HasColumnName("birth_date");
        
        builder.Property(p=>p.VaccinatedOrNot)
            .IsRequired()
            .HasColumnName("vaccinated_or_not");

        builder.Property(p => p.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasConversion<int>();

        builder.OwnsOne(p => p.Requisites, rb =>
        {
            rb.ToJson();

            rb.OwnsMany(r => r.Requisite, rlb =>
            {
                rlb.Property(rn => rn.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_NAME_LENGTH);

                rlb.Property(rd => rd.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            });
        });

        builder.Property(p => p.CreateDate)
            .IsRequired()
            .HasColumnName("create_date");

    }
}