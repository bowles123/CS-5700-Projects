using System;
using System.Drawing;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Collections.Generic;

namespace AppLayer.CommandPattern.Commands
{
    public class ScaleSelectedCommand : Command
    {
        private float scaleBy;
        private List<SeaCreature> wereScaled = new List<SeaCreature>();
        internal ScaleSelectedCommand() { ActualCommand = "SCALE"; }

        internal ScaleSelectedCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                scaleBy = (float) commandParameters[0];
            else
                scaleBy = 1.0F;
            ActualCommand = "SCALE";
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
                        creature.Size = new Size()
                        {
                            Width = Convert.ToInt16(Math.Round(creature.Size.Width * scaleBy, 0)),
                            Height = Convert.ToInt16(Math.Round(creature.Size.Height * scaleBy, 0))
                        };

                        wereScaled.Add(creature);
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
            if (Drawing == null || wereScaled.Count == 0) return false;

            foreach (SeaCreature creature in wereScaled)
            {
                if (creature != null)
                {
                    creature.Size = new Size()
                    {
                        Width = Convert.ToInt16(Math.Round(creature.Size.Width / scaleBy, 0)),
                        Height = Convert.ToInt16(Math.Round(creature.Size.Height / scaleBy, 0))
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
