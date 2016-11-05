using AppLayer.CommandPattern;
using AppLayer.DrawingComponents;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Drawing;
using OceanDrawing;

namespace UnitTests
{
    public class CommandTests
    {
        protected CommandFactory commandFactory = new CommandFactory();
        protected SeaCreatureFactory seaCreatureFactory = new SeaCreatureFactory()
        { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
            ReferenceType = typeof(OceanDrawingProgram) };
        protected Drawing drawing = new Drawing();
        protected SeaCreature seacreature;

        protected void drawingSetup(bool multiple)
        {
            drawing = new Drawing() { IsDirty = false, Factory = seaCreatureFactory };
            seacreature = seaCreatureFactory.Create(new ExtrinsicSeaCreature()
            {
                CreatureType = "Shark",
                IsSelected = true,
                Location = new Point(5, 5),
                Size = new Size(60, 60)
            });
            drawing.Add(seacreature);

            if (multiple)
            {
                seacreature = seaCreatureFactory.Create(new ExtrinsicSeaCreature()
                {
                    CreatureType = "Dolphin",
                    IsSelected = false,
                    Location = new Point(20, 24),
                    Size = new Size(60, 60)
                });
                drawing.Add(seacreature);

                seacreature = seaCreatureFactory.Create(new ExtrinsicSeaCreature()
                {
                    CreatureType = "Whale",
                    IsSelected = true,
                    Location = new Point(43, 24),
                    Size = new Size(50, 50)
                });
                drawing.Add(seacreature);
            }
            drawing.IsDirty = false;
        }
    }
}
