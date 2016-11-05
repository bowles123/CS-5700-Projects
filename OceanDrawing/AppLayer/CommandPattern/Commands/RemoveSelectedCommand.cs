using System.Collections.Generic;
using AppLayer.DrawingComponents.DrawingObjects;

namespace AppLayer.CommandPattern.Commands
{
    public class RemoveSelectedCommand : Command
    {
        private List<SeaCreature> wereSelected = new List<SeaCreature>();
        internal RemoveSelectedCommand() { ActualCommand = "REMOVE"; }

        public override bool Execute()
        {
            if (Drawing == null || Drawing.SeaCreatures.Count == 0) return false;

            foreach (SeaCreature creature in Drawing?.SeaCreatures)
            {
                if (creature.IsSelected)
                {
                    wereSelected.Add(creature);
                }
            }

            Drawing?.DeleteAllSelected();
            Drawing.IsDirty = true;
            return true;
        }

        public override bool Undo()
        {
            if (Drawing == null || wereSelected.Count == 0) return false;

            foreach (SeaCreature creature in wereSelected)
            {
                if (creature != null)
                {
                    Drawing.Add(creature);
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
