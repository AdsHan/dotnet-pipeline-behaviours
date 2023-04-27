using MediatR;
using PipelineBehaviours.API.Application.Messages.Commands;
using PipelineBehaviours.API.Application.Messages.Validators;
using PipelineBehaviours.API.Common;

namespace PipelineBehaviours.API.Application.Messages.Behaviors;

public class CreateProductBehavior : IPipelineBehavior<CreateProductCommand, BaseResult>
{
    public async Task<BaseResult> Handle(CreateProductCommand request, RequestHandlerDelegate<BaseResult> next, CancellationToken cancellationToken)
    {
        var validationResult = new CreateProductValidator().Validate(request);

        var result = new BaseResult();

        result.AddErrors(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

        return validationResult.IsValid
            ? await next()
            : result;
    }
}
