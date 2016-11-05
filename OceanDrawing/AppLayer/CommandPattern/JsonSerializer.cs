using System.Runtime.Serialization.Json;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Collections.Generic;

namespace AppLayer.CommandPattern
{
    public class JsonSerializer
    {
        private DataContractJsonSerializer objectSerializer;
        private DataContractJsonSerializer backgroundSerializer;
        private static JsonSerializer uniqueInstance = new JsonSerializer();

        public DataContractJsonSerializer getObjectSerializer() { return objectSerializer; }
        public DataContractJsonSerializer getBackgroundSerializer() { return backgroundSerializer; }
        public static JsonSerializer getInstance() { return uniqueInstance; }

        private JsonSerializer()
        {
            objectSerializer = new DataContractJsonSerializer(typeof(List<ExtrinsicSeaCreature>));
            backgroundSerializer = new DataContractJsonSerializer(typeof(string));
        }
    }
}
