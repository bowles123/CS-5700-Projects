using System.Collections.Generic;
using AppLayer.DrawingComponents.DrawingObjects;

namespace AppLayer.CommandPattern.Commands
{
    public class DeselectAllCommand : Command
    {
        private List<SeaCreature> deselected = new List<SeaCreature>();
        internal DeselectAllCommand() { ActualCommand = "DESELECT"; }

        public override bool Execute()
        {
            if (Drawing == null || Drawing.SeaCreatures.Count == 0) return false;

            foreach (SeaCreature creature in Drawing?.SeaCreatures)
            {
                if (creature.IsSelected)
                {
                    deselected.Add(creature);
                }
            }

            Drawing?.DeselectAll();
            return true;
        }

        public override bool Undo()
        {
            if (deselected.Count == 0) return false;

            foreach (SeaCreature creature in deselected)
            {
                if (creature != null)
                {
                    creature.IsSelected = !creature.IsSelected;
                    Drawing.IsDirty = true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
