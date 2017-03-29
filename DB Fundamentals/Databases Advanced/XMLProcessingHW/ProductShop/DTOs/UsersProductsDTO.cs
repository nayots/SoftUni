using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [XmlType(TypeName = "users")]
    public class UsersProductsDTO
    {
        public UsersProductsDTO()
        {
            this.users = new List<UsersAndProductsDTO>();
        }
        [XmlAttribute(AttributeName = "count")]
        public int userCount { get; set; }
        public List<UsersAndProductsDTO> users { get; set; }
    }
}
