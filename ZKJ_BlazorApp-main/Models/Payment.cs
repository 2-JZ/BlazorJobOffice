using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Payment
    {
        public int Id { get; set; } // Primary key

        // Stripe's PaymentIntent ID
        public string PaymentIntentId { get; set; }

        // Total amount paid (in your base currency, e.g., USD)
        public decimal Amount { get; set; }

    }
}
