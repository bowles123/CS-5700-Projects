using System;
using System.Collections.Generic;
using AppLayer.DrawingComponents.DrawingObjects;

namespace AppLayer.DrawingComponents
{
    public class SeaCreatureFactory
    {
        private readonly Dictionary<string, IntrinsicSeaCreature> creatures = 
            new Dictionary<string, IntrinsicSeaCreature>();
        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }
        public int getDictionarySize() { return creatures.Count; }

        public SeaCreature Create(ExtrinsicSeaCreature extrinsicState)
        {
            if (string.IsNullOrWhiteSpace(ResourceNamePattern) || extrinsicState == null) return null;
            string resourceName = string.Format(ResourceNamePattern, extrinsicState.CreatureType);

            IntrinsicSeaCreature treeWithIntrinsicState;
            if (creatures.ContainsKey(extrinsicState?.CreatureType))
                treeWithIntrinsicState = creatures[extrinsicState.CreatureType];
            else
            {
                treeWithIntrinsicState = new IntrinsicSeaCreature();
                treeWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                creatures.Add(extrinsicState.CreatureType, treeWithIntrinsicState);
            }

            return new SeaCreatureWithAllState(treeWithIntrinsicState, extrinsicState);
        }
    }
}
