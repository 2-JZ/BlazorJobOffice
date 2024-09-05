using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BlazorApp.Models;

namespace BlazorApp.Models
{
    public class Category
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        //public string? Description { get; set; }

        //public string? Picture { get; set; }

        //public string? CategoryURL { get; set; }

        //public int? IdSubCategory { get; set; }

        //public bool isActive { get; set; }

        //public DateTime CreatedCategoryId { get; set; }

        //public ICollection<SubCategory>? SubCategories { get; set; }

        //public virtual ICollection<Product> Products { get; set; } = new List<Product>();


        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //Foreign key to following higher category, if exists
        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }

        public List<ProductAttributes>? Attributes { get; set; }

        public List<Tag>? Tags { get; set; }

        // field for ordering childrens 
        public int? Order { get; set; }

        public string? ImagePath { get; set; } //for FromForm

        public byte[]? ImageData { get; set; }  // Store image as binary data



    }
}
