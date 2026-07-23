using FluentValidation;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoomMember.Validation
{
    public class UpdateClassRoomMemberValidation : AbstractValidator<UpdateClassRoomMemberDTO>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        public UpdateClassRoomMemberValidation(IAccountRepository accountRepository, IClassRoomRepository classRoomRepository)
        {
            _accountRepository = accountRepository;
            _classRoomRepository = classRoomRepository;

            RuleFor(e => e.StudentIDs).MustAsync(async (Model, Id, Token) =>
            {
                if (Model.StudentIDs.Count != Model.Phones.Count)
                {
                    return false;
                }
                return true;
            }).WithMessage("برخی از کاربران یافت نشدند.");
            RuleFor(e => e.StudentIDs).MustAsync(async (Ids, Token) =>
            {
                foreach (var id in Ids)
                {
                    if (!await _accountRepository.UserExistAsync(id))
                    {
                        return false;
                    }
                }
                return true;
            }).WithMessage("برخی از اعضای جدید یافت نشد.");
            RuleFor(e => e.ClasRoomId).MustAsync(async (Id, Token) =>
            {
                var classRoomExist = await _classRoomRepository.ExistAsync(Id);
                return classRoomExist;
            }).WithMessage((Id) => $"کلاس با آیدی {Id} یافت نشد.");
        }
    }
}
