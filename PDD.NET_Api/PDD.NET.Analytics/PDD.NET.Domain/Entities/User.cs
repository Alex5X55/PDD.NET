using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities;

public class User : BaseEntity
{
    public string Login { get; set; }

    public string Email { get; set; }
    
    public virtual IEnumerable<AnalyticsData> AnalyticsDatas { get; set; }
}