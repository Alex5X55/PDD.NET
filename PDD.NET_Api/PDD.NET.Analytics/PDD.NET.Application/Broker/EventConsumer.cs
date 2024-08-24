using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
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
        private readonly IDistributedCache _cache;

        public EventConsumer(IAnalyticsDataRepository analyticsDataRepository, IDistributedCache cache)
        {
            _analyticsDataRepository = analyticsDataRepository;
            _cache = cache;
        }

        public async Task Consume(ConsumeContext<MessageDto> context)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            MessageDto message = context.Message;

            AnalyticsData analyticsData = new AnalyticsData()
            {
                CreatedOn = message.CreatedOn,
                UserId = message.UserId,
                IsSeccess = message.IsSuccess
            };

            _analyticsDataRepository.Create(analyticsData);

            Console.WriteLine("Очистка кэша после обновления данных");
            await _cache.RemoveAsync("analytics_data_cache_key");
        }
    }
}
