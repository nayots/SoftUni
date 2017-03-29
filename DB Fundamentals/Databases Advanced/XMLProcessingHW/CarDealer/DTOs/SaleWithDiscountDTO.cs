using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs
{
    [XmlType(TypeName = "sale")]
    public class SaleWithDiscountDTO
    {
        [XmlElement("car")]
        public CarSalesDiscountDTO Car { get; set; }
        [XmlElement("customer-name")]
        public string CustomerName { get; set; }
        [XmlElement("discount")]
        public decimal Discount { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("price-with-discount")]
        public decimal DescountedPrice { get; set; }
    }
}
