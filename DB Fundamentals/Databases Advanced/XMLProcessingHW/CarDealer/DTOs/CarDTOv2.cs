using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs
{
    [XmlType(TypeName = "car")]
    public class CarDTOv2
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
        [XmlArray(ElementName = "parts")]
        [XmlArrayItem(ElementName = "part")]
        public List<PartDTO> Parts { get; set; }
    }
}
