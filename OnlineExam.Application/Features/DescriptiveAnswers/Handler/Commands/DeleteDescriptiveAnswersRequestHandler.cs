using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Identity;
namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class DeleteDescriptiveAnswersRequestHandler : IRequestHandler<DeleteDescriptiveAnswersRequest>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        private readonly IAuthServices _authServices;
        public DeleteDescriptiveAnswersRequestHandler(IDescriptiveAnswersRepository DescriptiveAnswersRepository,IAuthServices authServices)
        {
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
            _authServices = authServices;
        }

        public async Task Handle(DeleteDescriptiveAnswersRequest request, CancellationToken cancellationToken)
        {
            var answer = await _DescriptiveAnswersRepository.GetAsync(request.Id);

            var currentUser =await _authServices.GetCurrentUserIdAsync();
            var isAdmin=await _authServices.IsUserAdminAsync(currentUser);
            if (answer == null)
            {
                throw new NotFoundException($"پاسخی با آیدی {request.Id} یافت نشد.");
            }

            if (answer.StudentId!=currentUser && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی این عملیات را ندارید.");
            }        
            await _DescriptiveAnswersRepository.DeleteAsync(answer);
        }
    }
}
