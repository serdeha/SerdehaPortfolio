using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Data.Concrete.EntityFramework.Configurations
{
    public class MessageConfiguration:IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.MessageId);
        }
    }
}
