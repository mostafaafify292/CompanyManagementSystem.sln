using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company_DAL.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Salery)
                   .HasColumnType("decimal(18,2)");
            builder.Property(E => E.Gender)
                   .HasConversion
                   (
                      (Gender)=>Gender.ToString(),  //we hwa ray7 el DB
                      GenderAsString=>(Gender)Enum.Parse(typeof(Gender),GenderAsString ,true) //we hwa gay mn el DB
                   );
            builder.Property(E => E.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(E => E.Age)
                   .IsRequired(false);
            builder.Property(E => E.Address)
                   .IsRequired(false);
            builder.Property(E => E.PhoneNumber)
                   .IsRequired(false)
                   .HasColumnName("Phone Number");
            builder.HasOne(E=>E.Department)
                   .WithMany(E => E.Employees)
                   .HasForeignKey(E => E.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);
                   
                     

                  
                   
                   
        }
    }
}
