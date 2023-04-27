using MediatR;
using System.Text.Json.Serialization;

namespace PipelineBehaviours.API.Common;

public abstract class Command : IRequest<BaseResult>
{
    [JsonIgnore]
    public BaseResult BaseResult { get; set; }

    protected Command()
    {
        BaseResult = new BaseResult();
    }
}
