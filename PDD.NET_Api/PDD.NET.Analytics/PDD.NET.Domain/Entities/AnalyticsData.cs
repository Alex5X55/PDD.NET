using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities
{
    public class AnalyticsData : BaseEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public bool IsSeccess { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}