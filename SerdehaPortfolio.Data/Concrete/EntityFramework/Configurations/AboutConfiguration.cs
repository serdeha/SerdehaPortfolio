using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Data.Concrete.EntityFramework.Configurations
{
    public class AboutConfiguration:IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(a => a.AboutId);
        }
    }
}
