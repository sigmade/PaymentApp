using Domain.ValueObjects;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder
                .OwnsOne(a => a.Phone, b => b.Property(v => v.Value).HasColumnName(nameof(Phone)));
            builder
                .OwnsOne(a => a.Amount, b => b.Property(v => v.Value).HasColumnName(nameof(Amount)));
        }
    }
}
