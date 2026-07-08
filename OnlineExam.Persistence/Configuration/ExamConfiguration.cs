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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e=>e.EndDate).IsRequired();
            builder.Property(e => e.AllowedDelay).IsRequired();

            builder.HasOne(e => e.ClassRoom).WithMany(e => e.Exams).HasForeignKey(e => e.ClassId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Questions).WithOne(e => e.Exam).HasForeignKey(e => e.ExamId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.ExamLog).WithOne(e => e.Exam).HasForeignKey(e=>e.ExamId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
