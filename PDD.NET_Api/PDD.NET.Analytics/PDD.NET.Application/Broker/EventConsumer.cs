using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.NET.Application.Broker
{
    class EventConsumer : IConsumer<MessageDto>
    {
        public async Task Consume(ConsumeContext<MessageDto> context)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("Value: {0}", context.Message.Content);
        }
    }
}
