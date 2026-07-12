using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoomMember.Validation
{
    public class CreateClassRoomMemberValidation : AbstractValidator<CreateClassRoomMemberDTO>
    {
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IClassRoomRepository _classRepository;
        public CreateClassRoomMemberValidation(IClassRoomMembersRepository classRoomMembersRepository, IClassRoomRepository classRoomRepository)
        {
            _classRoomMembersRepository = classRoomMembersRepository;
            _classRepository = classRoomRepository;

            RuleFor(e => e.ClassRomeId).GreaterThan(0).MustAsync(async (Id, Token) =>
            {
                var exist = await _classRepository.ExistAsync(Id);
                return exist;
            }).WithMessage("کلاس با آیدی {PropertyValue} وجود ندارد.");

            RuleFor(e=>e.StudentIDs).MustAsync(async (Model,Id, Token) =>
            {
                var classStudents = await _classRoomMembersRepository.GetStudentByClassIdAsync(Model.ClassRomeId);
                var existStudents= Id.Where(e=> classStudents.Contains(e)).ToList();
                if(existStudents.Any())
                {
                    return false;
                }
                return true;
            }).WithMessage("برخی اعضا جدید تکراری هستند.");
        }
    }
}
