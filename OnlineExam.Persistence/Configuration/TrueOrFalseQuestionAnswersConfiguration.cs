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
    public class TrueOrFalseQuestionAnswersConfiguration : IEntityTypeConfiguration<TrueOrFalseQuestionAnswers>
    {
        public void Configure(EntityTypeBuilder<TrueOrFalseQuestionAnswers> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
        }
    }
}
