using System;
using System.Threading.Tasks;
using Dnc.Common;
using Dnc.Common.Events;
using Store.Messages.Products;

namespace Store.Api.Handlers
{
    public class ProductCreatedHandler : IEventHandler<ProductCreated>
    {
        public Task HandleAsync(ProductCreated @event, ICorrelationContext context)
        {
            Console.WriteLine($"{@event.Name} created with price {@event.Price}");
            return Task.CompletedTask;
        }
    }
}
