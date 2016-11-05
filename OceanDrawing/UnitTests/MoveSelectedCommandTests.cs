using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.CommandPattern.Commands;
using AppLayer.DrawingComponents;
using OceanDrawing;
using System.Drawing;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class MoveSelectedCommandTests: CommandTests
    {
        [TestMethod]
        public void MoveSelectedCommandWithNonEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(false);
            Command command = commandFactory.Create("move", new Point(10, 0));
            List<Point> prevLocations = new List<Point>();
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("MOVE"));
            command.Drawing = drawing;
            foreach (SeaCreature seacreature in command.Drawing.SeaCreatures)
                if (seacreature.IsSelected) prevLocations.Add(seacreature.Location);

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            Assert.IsTrue(command.Execute());
            Assert.IsTrue(command.Drawing.IsDirty);
            for (int i = 0, j = 0; i < command.Drawing.SeaCreatures.Count; i++)
            {
                Assert.IsNotNull(command.Drawing.SeaCreatures[i]);
                if (command.Drawing.SeaCreatures[i].IsSelected)
                {
                    SeaCreature creature = command.Drawing.SeaCreatures[i];
                    Assert.AreEqual((prevLocations[j].X + 10  + creature.Size.Width / 2) - 
                            creature.Size.Width / 2, creature.Location.X);
                    Assert.AreEqual(prevLocations[j].Y, creature.Location.Y);
                    j++;
                }
            }

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsTrue(command.Undo());
            Assert.IsTrue(command.Drawing.IsDirty);
            for (int i = 0, j = 0; i < command.Drawing.SeaCreatures.Count; i++)
            {
                if (command.Drawing.SeaCreatures[i].IsSelected)
                {
                    Assert.AreEqual(prevLocations[j].X, command.Drawing.SeaCreatures[i].Location.X);
                    Assert.AreEqual(prevLocations[j].Y, command.Drawing.SeaCreatures[i].Location.Y);
                    j++;
                }
            }
        }

        [TestMethod]
        public void MoveSelectedCommandEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("move");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("MOVE"));
            command.Drawing = drawing;

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute and undo with a non-null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Drawing.IsDirty);
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);
        }

        [TestMethod]
        public void MoveSelectedCommandNullDrawingTest()
        {
            // Test that the command was created correctly.
            Command command = commandFactory.Create("move");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("MOVE"));
            command.Drawing = null;

            // Test undo with no previous drawing & a null Drawing object.
            Assert.IsFalse(command.Undo());

            // Test execute and undo with a null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Undo());
        }

        [TestMethod]
        public void MoveSelectedCommandParametersTest()
        {
            // Test that the command was created correctly.
            drawingSetup(false);
            Command command = commandFactory.Create("move", new Point(10, 15));
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("MOVE"));
            command.Drawing = drawing;
            Point prevLocation = new Point(seacreature.Location.X, seacreature.Location.Y);

            Assert.IsTrue(command.Execute());
            SeaCreature creature = command.Drawing.SeaCreatures[0];
            Assert.AreEqual(seacreature.Size.Height, creature.Size.Height);
            Assert.AreEqual(seacreature.Size.Width, creature.Size.Width);
            Assert.AreEqual((prevLocation.X + 10 + creature.Size.Width / 2) -
                            creature.Size.Width / 2, creature.Location.X);
            Assert.AreEqual((prevLocation.Y + 15 + creature.Size.Width / 2) -
                            creature.Size.Width / 2, creature.Location.Y);

            // Test the same things as above with no command parameters.
            drawingSetup(false);
            command = commandFactory.Create("move");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("MOVE"));
            command.Drawing = drawing;
            prevLocation = new Point(seacreature.Location.X, seacreature.Location.Y);

            Assert.IsTrue(command.Execute());
            creature = command.Drawing.SeaCreatures[0];
            Assert.AreEqual(seacreature.Size.Height, creature.Size.Height);
            Assert.AreEqual(seacreature.Size.Width, creature.Size.Width);
            Assert.AreEqual(prevLocation.X, creature.Location.X);
            Assert.AreEqual(prevLocation.Y, creature.Location.Y);
        }
    }
}
