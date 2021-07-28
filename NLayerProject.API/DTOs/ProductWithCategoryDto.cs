using System;
namespace NLayerProject.API.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public ProductWithCategoryDto()
        {
        }

        public CategoryDto Category { get; set; }
    }
}
