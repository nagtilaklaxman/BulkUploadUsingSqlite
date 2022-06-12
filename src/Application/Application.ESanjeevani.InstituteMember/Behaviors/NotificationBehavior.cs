
using Application.ESanjeevani.InstituteMember.Commands;
using MediatR;

namespace Application.ESanjeevani.InstituteMember.Behaviors;

public class NotificationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : InstituteMemberCommandResponse 
{
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Console.WriteLine($"Notification behavior : {typeof(TRequest).Name}");
            var response = await next();
            Console.WriteLine($"Notification behavior : {response.Message}");
            return response;
        }
}

