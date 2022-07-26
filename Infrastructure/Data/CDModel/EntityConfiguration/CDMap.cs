using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDShopApp.Domain;

namespace CDShopApp.Infrastructure.Data.CDModel.EntityConfigurations;

public class CDMap : IEntityTypeConfiguration<CD>
{
    public void Configure( EntityTypeBuilder<CD> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name);
        builder.Property(x => x.Artist);
        builder.Property(x => x.ReleaseDate);
        builder.Property(x => x.Price);
    }
}