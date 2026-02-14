using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;

namespace TodoList.Data.Mappings {
    public class UserMap : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
