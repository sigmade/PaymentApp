using Domain.Models;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Config
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .OwnsOne(a => a.Phone, b => b.Property(v => v.Value).HasColumnName(nameof(Phone)));
            builder
                .OwnsOne(a => a.Amount, b => b.Property(v => v.Value).HasColumnName(nameof(Amount)));
        }
    }
}
