using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Dtos.ProductDto
{
    public class ProductDetailPageDto
    {
        public ProductDto product { get; set; }
        public List<ProductDto> ProductSimilar { get; set; }
    }
}
