﻿using System.Collections.Generic;
using System;

namespace BlazorApp.Models
{
    public class ShoppingCart
    {
        public int CartId { get; set; }  // Primary Key

        public int? UserId { get; set; }  // Foreign Key to the User (Nullable for anonymous users)

        public DateTime? CreatedAt { get; set; } = DateTime.Now;  // Creation timestamp (Nullable)

        public string? Status { get; set; } = "Active";  // Cart status (Nullable, default 'Active')

        public decimal? TotalAmount { get; set; }  // Total amount for the shopping cart (Nullable)

        // Navigation property for Cart Items (1-to-Many relationship)
        public List<CartItem> Items { get; set; } = new List<CartItem>();  // List is initialized and no need for nullable
    }
}
