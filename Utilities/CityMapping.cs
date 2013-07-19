using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
namespace EFCodeFirstWithMapping.Utilities
{
    public class CityMapping : EntityTypeConfiguration<City>
    {
        public CityMapping()
        {
            Property(x => x.ID).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.CreateDate).IsRequired();
            ToTable("Cities");
        }
    }
}