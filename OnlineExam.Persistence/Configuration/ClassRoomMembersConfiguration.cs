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
    public class ClassRoomMembersConfiguration : IEntityTypeConfiguration<ClassRoomMembers>
    {
        public void Configure(EntityTypeBuilder<ClassRoomMembers> builder)
        {
            builder.HasKey(e => new {e.StudentId,e.ClassRomeId});
            builder.Property(e => e.ClassRomeId).IsRequired();
            builder.Property(e => e.StudentId).IsRequired();
        }
    }
}
