using System;
using System.Drawing;
using AppLayer.DrawingComponents.DrawingObjects;

namespace AppLayer.CommandPattern.Commands
{
    public class AddCreatureCommand : Command
    {
        private const int NormalWidth = 80;
        private const int NormalHeight = 80;

        private readonly string creatureType;
        private Point location;
        private readonly float scale;
        internal AddCreatureCommand() { ActualCommand = "ADD"; }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="commandParameters">An array of parameters, where
        ///     [1]: string     tree type -- a fully qualified resource name
        ///     [2]: Point      center location for the tree, defaut = top left corner
        ///     [3]: float      scale factor</param>
        internal AddCreatureCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                creatureType = commandParameters[0] as string;

            if (commandParameters.Length > 1)
                location = (Point)commandParameters[1];
            else
                location = new Point(0, 0);

            if (commandParameters.Length > 2)
                scale = (float)commandParameters[2];
            else
                scale = 1.0F;
            ActualCommand = "ADD";
        }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(creatureType) || Drawing == null) return false;

            Size creatureSize = new Size()
            {
                Width = Convert.ToInt16(Math.Round(NormalWidth * scale, 0)),
                Height = Convert.ToInt16(Math.Round(NormalHeight * scale, 0))
            };

            Point creatureLocation = new Point(
                location.X - creatureSize.Width / 2, location.Y - creatureSize.Height / 2);

            ExtrinsicSeaCreature extrinsicState = new ExtrinsicSeaCreature()
            {
                CreatureType = creatureType,
                Location = creatureLocation,
                Size = creatureSize
            };

            SeaCreature creature = Drawing.Factory.Create(extrinsicState);
            Drawing.Add(creature);
            return true;
        }

        public override bool Undo()
        {
            SeaCreature creature = Drawing?.FindSeaCreatureAt(location);

            if (creature != null)
            {
                Drawing.RemoveSeaCreature(creature);
                return true;
            }
            return false;
        }
    }
}
