using Microsoft.EntityFrameworkCore;
using Burak.Boilerplate.Data.EntityModels;

namespace Burak.Boilerplate.Data.Config
{
    public class SqlServerSettingConfig : IEntityTypeConfiguration<Setting>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable(nameof(Setting));
            builder.HasKey(model => model.Id);
        }
    }
}
