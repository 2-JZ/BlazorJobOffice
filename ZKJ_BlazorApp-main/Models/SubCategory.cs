using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class SubCategory
    {
        public string? SubCategoryDescription { get; set; }  
        public string SubCategoryName { get; set; }  
        public int? CategoryId { get; set; }  
        public Category? Category { get; set; } 
        public string? Picture { get; set; }  
        public string? SubCategoryURL { get; set; } 
    }
}
