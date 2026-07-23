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
    public class DescriptiveAnswersConfiguration : IEntityTypeConfiguration<DescriptiveAnswers>
    {
        public void Configure(EntityTypeBuilder<DescriptiveAnswers> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).UseIdentityColumn();
            builder.Property(e => e.StudentAnswer).HasMaxLength(1000);
            builder.Property(e => e.StudentId).IsRequired();
            builder.Property(e => e.StudentScore).HasPrecision(5, 2);
        }
    }
}
