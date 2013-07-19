using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
namespace EFCodeFirstWithMapping.Utilities
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(p => p.ID).IsRequired().HasColumnName("ID");
            Property(p => p.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
            Property(p => p.EmailID).IsRequired().HasMaxLength(50).HasColumnName("EmailID");
            Property(p => p.Password).IsRequired().HasMaxLength(50).HasColumnName("Password");
            Property(p => p.CreateDate).IsRequired().HasColumnName("CreateDate");
            Property(p => p.IsDeleted).IsRequired().HasColumnName("IsDeleted");
            Property(p => p.City).IsOptional().HasColumnName("City");
            Property(p => p.Address).IsOptional();
            ToTable("Users");

        }
    }
}