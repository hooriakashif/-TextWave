using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // 1. ADD THIS LINE

namespace TextWave.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string PlanName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // 2. ADD THIS ATTRIBUTE
        public decimal Amount { get; set; }

        public string BillingType { get; set; } // Monthly or Annual

        [Required]
        public string CardholderName { get; set; }

        [Required]
        public string CardLastFour { get; set; }

        public string PaymentMethod { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public string OrderNumber { get; set; }

        public string Status { get; set; } // Paid, Pending, Failed

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}