using System.ComponentModel.DataAnnotations;

namespace TextWave.Models
{
    public class PricingPlan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MonthlyPrice { get; set; }
        public decimal AnnualPrice { get; set; }
        public int SMSCount { get; set; }
        public int SenderIDs { get; set; }
        public string SupportType { get; set; }
        public bool HasApiAccess { get; set; }
        public bool HasTwoWaySms { get; set; }
        public bool HasAnalytics { get; set; }
        public bool HasCustomIntegration { get; set; }
        public bool IsFeatured { get; set; }
    }
}