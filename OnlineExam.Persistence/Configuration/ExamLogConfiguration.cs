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
    public class ExamLogConfiguration : IEntityTypeConfiguration<ExamLog>
    {
        public void Configure(EntityTypeBuilder<ExamLog> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();

            builder.HasOne(e=>e.LogType).WithMany(e=>e.examLogs).HasForeignKey(e=>e.LogTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
