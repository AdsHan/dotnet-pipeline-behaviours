using MediatR;

namespace PipelineBehaviours.API.Application.Messages.Behaviors;

public class GenericBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Lógica do pipeline antes da execução do manipulador

        var result = await next();

        return result;

        // Lógica do pipeline após a execução do manipulador
    }
}
