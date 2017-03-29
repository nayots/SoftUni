using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [XmlType(TypeName = "sold-products")]
    public class SoldProductsDTO
    {
        public SoldProductsDTO()
        {
            this.SoldProducts = new List<SoldProductOneLineDTO>();
        }
        [XmlAttribute(AttributeName = "count")]
        public int Count { get; set; }
        [XmlElement(ElementName = "product")]
        public List<SoldProductOneLineDTO> SoldProducts { get; set; }
    }
}
