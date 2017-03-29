using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [XmlType(TypeName = "category")]
    public class CategoriesProductsDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("products-count")]
        public int ProductsCount { get; set; }
        [XmlElement("average-price")]
        public decimal? AveragePrice { get; set; }
        [XmlElement("total-revenue")]
        public decimal? TotalRevenue { get; set; }
    }
}
