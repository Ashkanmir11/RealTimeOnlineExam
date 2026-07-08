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
    public class TrueOrFalseQuestionConfiguration : IEntityTypeConfiguration<TrueOrFalseQuestion>
    {
        public void Configure(EntityTypeBuilder<TrueOrFalseQuestion> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).UseIdentityColumn();
            builder.HasMany(e=>e.Answers).WithOne(e=>e.TrueOrFalseQuestion).HasForeignKey(e=>e.TrueOrFalseQuestionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
