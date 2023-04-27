using MediatR;
using Microsoft.EntityFrameworkCore;
using PipelineBehaviours.API.Application.Messages.Behaviors;
using PipelineBehaviours.API.Application.Messages.Commands;
using PipelineBehaviours.API.Application.Services;
using PipelineBehaviours.API.Common;
using PipelineBehaviours.API.Data;

namespace PipelineBehaviours.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services)
    {
        services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("CatalogDB"));

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
            x.AddOpenBehavior(typeof(GenericBehavior<,>));
            x.AddBehavior<IPipelineBehavior<CreateProductCommand, BaseResult>, CreateProductBehavior>();
        });

        services.AddTransient<ProductPopulateService>();

        return services;
    }
}
