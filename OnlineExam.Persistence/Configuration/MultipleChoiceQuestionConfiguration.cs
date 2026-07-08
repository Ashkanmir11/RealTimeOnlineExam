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
    public class MultipleChoiceQuestionConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Choices).IsRequired();
            builder.Property(e=>e.CorrectChoice).IsRequired();

            builder.HasMany(e => e.Answers).WithOne(e => e.MultipleChoiceQuestion).HasForeignKey(e => e.MultipleChoiceQuestionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
