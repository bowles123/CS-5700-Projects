using System.Drawing;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Collections.Generic;

namespace AppLayer.CommandPattern.Commands
{
    public class MoveSelectedCommand : Command
    {
        private Point moveBy;
        private List<SeaCreature> wereMoved = new List<SeaCreature>();
        internal MoveSelectedCommand() { ActualCommand = "MOVE"; }

        internal MoveSelectedCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                moveBy = (Point)commandParameters[0];
            else
                moveBy = new Point(0, 0);
            ActualCommand = "MOVE";
        }

        public override bool Execute()
        {
            if (Drawing == null || Drawing.SeaCreatures.Count == 0) return false;

            foreach (SeaCreature creature in Drawing.SeaCreatures)
            {
                if (creature != null)
                {
                    if (creature.IsSelected)
                    {
                        creature.Location = new Point()
                        {
                            X = (creature.Location.X + moveBy.X  + creature.Size.Width / 2) - 
                            creature.Size.Width / 2,
                            Y = (creature.Location.Y + moveBy.Y + creature.Size.Height / 2) - 
                            creature.Size.Height / 2
                        };

                        wereMoved.Add(creature);
                        Drawing.IsDirty = true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Undo()
        {
            if (Drawing == null || wereMoved.Count == 0) return false;


            foreach (SeaCreature creature in wereMoved)
            {
                if (creature != null)
                {
                    creature.Location = new Point()
                    {
                        X = (creature.Location.X - moveBy.X + creature.Size.Width / 2) -
                            creature.Size.Width / 2,
                        Y = (creature.Location.Y - moveBy.Y + creature.Size.Height / 2) -
                            creature.Size.Height / 2
                    };
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
