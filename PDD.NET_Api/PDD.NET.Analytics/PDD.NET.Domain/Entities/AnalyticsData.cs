using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities
{
    public class AnalyticsData : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
    
        public string Login { get; set; }
    
        public bool IsSuccess { get; set; }
    }
}