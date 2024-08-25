using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;
using PDD.NET.Application.Repositories;
using System.Text.Json;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;

public sealed class GetAllAnalyticsDataHandler : IRequestHandler<GetAllAnalyticsDataRequest, IEnumerable<GetAllAnalyticsDataResponse>>
{
    private readonly IAnalyticsDataRepository _analyticsDataRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IDistributedCache _cache;

    public GetAllAnalyticsDataHandler(IAnalyticsDataRepository analyticsDataRepository, IMapper mapper, IDistributedCache cache, ILogger<GetAllAnalyticsDataHandler> logger)
    {
        _analyticsDataRepository = analyticsDataRepository;
        _mapper = mapper;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IEnumerable<GetAllAnalyticsDataResponse>> Handle(GetAllAnalyticsDataRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("проверяем кэш");
        var cachedData = await _cache.GetStringAsync("analytics_data_cache_key");
        if (cachedData != null)
        {
            Console.WriteLine("Данные в кэше существуют, возвращаем их");
            return JsonSerializer.Deserialize<IEnumerable<GetAllAnalyticsDataResponse>>(cachedData);
        }

        var userAnswerHistories = await _analyticsDataRepository.GetAll(cancellationToken);

        Console.WriteLine($"Сериализация и сохранение данных в кэш");
        
        var serializedData = JsonSerializer.Serialize(userAnswerHistories);
        await _cache.SetStringAsync("analytics_data_cache_key", serializedData, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1) // Настройте время жизни кэша
        });

        _logger.LogInformation($"All userAnswerHistories returned");

        return _mapper.Map<IEnumerable<GetAllAnalyticsDataResponse>>(userAnswerHistories);
    }
}