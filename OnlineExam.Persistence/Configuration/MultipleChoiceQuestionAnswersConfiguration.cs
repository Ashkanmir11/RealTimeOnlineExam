using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Configuration
{
    public class MultipleChoiceQuestionAnswersConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestionAnswers>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestionAnswers> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).UseIdentityColumn();

        }
    }
}
