using MediatR;
using PipelineBehaviours.API.Common;
using PipelineBehaviours.API.Data;
using PipelineBehaviours.API.Data.Entities;

namespace PipelineBehaviours.API.Application.Messages.Commands;

public class ProductCommandHandler : CommandHandler,
    IRequestHandler<CreateProductCommand, BaseResult>
{
    private readonly CatalogDbContext _dbContext;

    public ProductCommandHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BaseResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new ProductModel()
        {
            Title = command.Title,
            Description = command.Description,
            Price = command.Price,
            Quantity = command.Quantity
        };

        _dbContext.Add(product);

        await _dbContext.SaveChangesAsync();

        BaseResult.Response = product.Id;

        return BaseResult;
    }
}
