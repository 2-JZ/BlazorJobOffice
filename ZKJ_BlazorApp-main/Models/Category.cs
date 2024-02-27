using System.Collections.Generic;
using System;

namespace BlazorApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Picture { get; set; }

        public string? CategoryURL { get; set; }

        public int? IdSubCategory { get; set; }

        public bool isActive { get; set; }

        public DateTime CreatedCategoryId { get; set; } 

        public ICollection<SubCategory>? SubCategories { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
