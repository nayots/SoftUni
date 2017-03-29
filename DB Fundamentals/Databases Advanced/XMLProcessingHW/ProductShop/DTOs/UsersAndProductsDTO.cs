using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [XmlType(TypeName = "user")]
    public class UsersAndProductsDTO
    {
        [XmlAttribute(AttributeName = "first-name")]
        public string FirstName { get; set; }
        [XmlAttribute(AttributeName = "last-name")]
        public string LastName { get; set; }
        [XmlAttribute(AttributeName = "age")]
        public int Age { get; set; }
        [XmlElement(ElementName = "sold-products")]
        public SoldProductsDTO ProductsSold { get; set; }
    }
}
