using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [XmlType(TypeName = "user")]
    public class SellerDTO
    {
        public SellerDTO()
        {
            this.SoldProducts = new List<SoldProductDTO>();
        }
        [XmlAttribute(AttributeName = "first-name")]
        public string FirstName { get; set; }
        [XmlAttribute(AttributeName = "last-name")]
        public string LastName { get; set; }
        [XmlArray("sold-products")]
        [XmlArrayItem("product")]
        public List<SoldProductDTO> SoldProducts { get; set; }
    }
}
