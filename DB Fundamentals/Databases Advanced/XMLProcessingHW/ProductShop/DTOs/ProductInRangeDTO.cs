using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{   [XmlType(TypeName ="product")]
    public class ProductInRangeDTO
    {
        [XmlAttribute(AttributeName ="name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "price")]
        public decimal Price { get; set; }
        [XmlAttribute(AttributeName = "seller")]
        public string Seller { get; set; }
    }
}
