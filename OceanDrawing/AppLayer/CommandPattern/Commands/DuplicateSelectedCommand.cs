using System.Collections.Generic;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.CommandPattern.Commands
{
    public class DuplicateSelectedCommand : Command
    {
        public SeaCreatureFactory Factory { get; set; }
        private List<SeaCreature> addedObjects = new List<SeaCreature>();
        internal DuplicateSelectedCommand() { ActualCommand = "DUPLICATE"; }

        public override bool Execute()
        {
            if (Drawing == null) return false;
            int origCount = Drawing.SeaCreatures.Count;
            if (origCount == 0) return false;

            for (int i = 0; i < origCount; i++)
            {
                if (Drawing.SeaCreatures[i].IsSelected)
                {
                    SeaCreatureWithAllState creature =
                        Drawing.SeaCreatures[i] as SeaCreatureWithAllState;
                    ExtrinsicSeaCreature extrinsicState = new ExtrinsicSeaCreature()
                    {
                        CreatureType = creature.ActualCreature,
                        IsSelected = creature.IsSelected,
                        Location = new Point(creature.Location.X, creature.Location.Y),
                        Size = new Size(creature.Size.Width, creature.Size.Height)
                    };
                    SeaCreature newCreature = Factory.Create(extrinsicState);
                    newCreature.Location = new Point(
                        creature.Location.X + creature.Size.Width, creature.Location.Y);
                    addedObjects.Add(newCreature);
                    Drawing.Add(newCreature);
                }
            }
            return true;
        }

        public override bool Undo()
        {
            if (addedObjects.Count == 0 || Drawing == null) return false;

            foreach (SeaCreatureWithAllState creature in addedObjects)
                Drawing?.RemoveSeaCreature(Drawing?.FindSeaCreatureById(creature.CreatureId));
            return true;
        }
    }
}
