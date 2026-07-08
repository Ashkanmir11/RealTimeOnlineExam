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
    public class DescriptiveQuestionAnswersConfiguration : IEntityTypeConfiguration<DescriptiveQuestionAnswers>
    {
        public void Configure(EntityTypeBuilder<DescriptiveQuestionAnswers> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).UseIdentityColumn();
            builder.Property(e => e.StudentAnswer).HasMaxLength(1000);
            builder.Property(e => e.StudentId).IsRequired();
        }
    }
}
