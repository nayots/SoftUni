using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs
{
    [XmlType(TypeName ="car")]
    public class CarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
