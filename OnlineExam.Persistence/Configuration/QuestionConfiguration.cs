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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.QuestionText).IsRequired().HasMaxLength(300);
            builder.Property(e => e.CorrectAnswer).IsRequired().IsRequired().HasMaxLength(1000);
            builder.Property(e=>e.StudentAnswer).HasMaxLength(1000);
            builder.Property(e => e.TotalScore).IsRequired();
            
            builder.HasOne(e=>e.QuestionType).WithMany(e=>e.Questions).HasForeignKey(e=>e.QuestionTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Exam).WithMany(e => e.Questions).HasForeignKey(e => e.ExamId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
