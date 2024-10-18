using System.Collections.Generic;
using System;
using System.Linq;

namespace BlazorApp.Models
{
    public class ShoppingCartModel
    {
        public int CartId { get; set; }  // Primary Key

        public int? UserId { get; set; }  // Foreign Key to the User (Nullable for anonymous users)

        public DateTime? CreatedAt { get; set; } = DateTime.Now;  // Creation timestamp (Nullable)

        public string? Status { get; set; } = "Active";  // Cart status (Nullable, default 'Active')

        public decimal? Amount { get; set; }  // Total amount for the shopping cart (Nullable)

        // Navigation property for Cart Items (1-to-Many relationship)
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Method to calculate the total amount for the shopping cart
        public decimal GetTotalAmount()
        {
            return Items.Sum(item => (item.Price ?? 0) * item.Quantity ?? 0);  // Using ?? to default null prices to 0
        }
    }


}
