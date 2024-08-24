using AutoMapper;
using MassTransit;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.NET.Application.Broker
{
    class EventConsumer : IConsumer<MessageDto>
    {
        private readonly IAnalyticsDataRepository _analyticsDataRepository;

        public EventConsumer(IAnalyticsDataRepository analyticsDataRepository)
        {
            _analyticsDataRepository = analyticsDataRepository;
        }

        public async Task Consume(ConsumeContext<MessageDto> context)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            Console.WriteLine("Value: {0}", context.Message.UserId.ToString());
            Console.WriteLine("Value: {0}", context.Message.CreatedOn);

            MessageDto message = context.Message;

            AnalyticsData analyticsData = new AnalyticsData()
            {
                CreatedOn = message.CreatedOn,
                UserId = message.UserId,
                IsSeccess = message.IsSuccess
            };

            _analyticsDataRepository.Create(analyticsData);
        }
    }
}
