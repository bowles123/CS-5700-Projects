using System.Drawing;
using AppLayer.DrawingComponents.DrawingObjects;

namespace AppLayer.CommandPattern.Commands
{
    public class SelectCommand : Command
    {
        private readonly Point location;
        internal SelectCommand() { ActualCommand = "SELECT"; }

        internal SelectCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                location = (Point)commandParameters[0];
            ActualCommand = "SELECT";
        }

        public override bool Execute()
        {
            if (Drawing == null) return false;
            SeaCreature creature = Drawing?.FindSeaCreatureAt(location);

            if (creature != null)
            {
                creature.IsSelected = !creature.IsSelected;
                Drawing.IsDirty = true;
                return true;
            }
            return false;
        }

        public override bool Undo()
        {
            if (Drawing == null) return false;
            SeaCreature creature = Drawing?.FindSeaCreatureAt(location);

            if (creature != null)
            {
                creature.IsSelected = !creature.IsSelected;
                Drawing.IsDirty = true;
                return true;
            }
            return false;
        }
    }
}
