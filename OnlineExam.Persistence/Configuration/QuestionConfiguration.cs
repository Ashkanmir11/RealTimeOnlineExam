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
            builder.Property(e => e.TotalScore).IsRequired();
            builder.Property(e => e.TotalScore).HasPrecision(6, 2);
            builder.HasOne(e=>e.TrueOrFalseQuestion).WithMany(e=>e.Question).HasForeignKey(e=>e.TrueOrFalseQuestionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.DescriptiveQuestion).WithMany(e => e.Question).HasForeignKey(e => e.DescriptiveQuestionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.MultipleChoiceQuestion).WithMany(e => e.Question).HasForeignKey(e => e.MultipleChoiceQuestionId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
