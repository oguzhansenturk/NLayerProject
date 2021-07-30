using System;
namespace NLayerProject.Web.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public ProductWithCategoryDto()
        {
        }

        public CategoryDto Category { get; set; }
    }
}
