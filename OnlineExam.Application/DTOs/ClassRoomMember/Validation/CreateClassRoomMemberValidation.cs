using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

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
            RuleFor(e => e.StudentIDs).MustAsync(async (Model, Id, Token) =>
            {
                if (Model.StudentIDs.Count != Model.Phones.Count)
                {
                    return false;
                }
                return true;
            }).WithMessage("برخی از کاربران یافت نشدند.");
            RuleFor(e => e.StudentIDs).MustAsync(async (Model, Id, Token) =>
            {
                var classStudents = await _classRoomMembersRepository.GetStudentByClassIdAsync(Model.ClassRomeId);

                var existStudents = Id.Where(e => classStudents.Contains(e)).ToList();
                if (existStudents.Any())
                {
                    return false;
                }
                return true;
            }).WithMessage("برخی اعضا جدید تکراری هستند.");

        }
    }
}
