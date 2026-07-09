using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Configuration
{
    public class ClassRoomConfiguration : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).UseIdentityColumn();
            builder.Property(e => e.ClassName).IsRequired().HasMaxLength(150);
            

            builder.HasMany(e => e.Exams).WithOne(e => e.ClassRoom);
            
            

        }
    }
}
