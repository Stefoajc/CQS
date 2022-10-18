using CQS.DB.Models;
using MediatR;
using Newtonsoft.Json;

namespace CQS.MediatR.Commands.Aspects;

public interface IAuditableEntity : IRequest
{
    public Guid Id { get; }
}

public class AuditBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        if(request is IAuditableEntity)
        {
            var entry = new Activity
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                Data = JsonConvert.SerializeObject(request)
            };
        }

        return response;
    }
}
