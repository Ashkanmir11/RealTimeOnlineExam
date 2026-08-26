using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OnlineExam.Application.Constants;
using OnlineExam.Application.Features.ExamAttampt.Request.Queries;
namespace OnlineExam.Api.Hubs
{

    public class ExamHub : Hub
    {
        private readonly IMediator _meditor;
        public ExamHub(IMediator mediator)
        {
            _meditor = mediator;
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("OnConnectMassage", "You Are Connected");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("OnDisconnect", "You Are Disconnected");
            await base.OnDisconnectedAsync(exception);
        }

        [Authorize]
        public async Task ReceiveRemaindSeconds(int examId)
        {
            try
            {
                bool examEnded = false;
                while (!examEnded)
                {
                    await Task.Delay(1000);
                    var userId = Context.User?.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.UserId)?.Value;
                    var remainingSeconds = await _meditor.Send(new GetExamRemainSecondsRequest() { ExamId = examId, currentUser = userId });
                    if (remainingSeconds == 0)
                    {
                        examEnded = true;
                    }
                    await Clients.Caller.SendAsync("ReceiveRemaindSeconds", Convert.ToInt32(remainingSeconds));
                }

            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ReceiveRemaindSeconds", ex.Message);
            }
        }

    }
}
