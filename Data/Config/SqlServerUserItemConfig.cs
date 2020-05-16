using Burak.Boilerplate.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Data.Config
{
    public class SqlServerUserItemConfig : IEntityTypeConfiguration<UserItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserItem> builder)
        {
            builder.ToTable(nameof(UserItem));
            builder.HasKey(model => model.Id);

            builder.HasOne(pt => pt.User)
            .WithMany(p => p.UserItems)
            .HasForeignKey(pt => pt.UserId);
            
            builder.HasOne(pt => pt.Item)
            .WithMany(p => p.UserItems)
            .HasForeignKey(pt => pt.ItemId);

        }
    }
}
