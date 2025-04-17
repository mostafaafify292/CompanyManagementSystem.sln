using Company_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_DAL.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id)
                   .UseIdentityColumn(10, 10);
            builder.Property(d => d.Code)
                   .IsRequired(true);
            builder.Property(d => d.Name)
                   .IsRequired(true);
        }
    }
}
