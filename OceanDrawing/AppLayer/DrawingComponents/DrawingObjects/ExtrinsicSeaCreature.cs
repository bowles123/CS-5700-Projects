using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents.DrawingObjects
{
    [DataContract]
    public class ExtrinsicSeaCreature
    {
        [DataMember]
        public string CreatureType { get; set; }

        [DataMember]
        public Point Location { get; set; }

        [DataMember]
        public Size Size { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }
    }
}
