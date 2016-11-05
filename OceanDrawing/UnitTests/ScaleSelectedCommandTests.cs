using AppLayer.CommandPattern.Commands;
using AppLayer.DrawingComponents.DrawingObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OceanDrawing;
using AppLayer.DrawingComponents;
using System.Drawing;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ScaleSelectedCommandTests: CommandTests
    {
        [TestMethod]
        public void ScaleSelectedCommandWithNonEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(true);
            Command command = commandFactory.Create("scale", 0.5F);
            List<Size> prevSizes = new List<Size>();
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SCALE"));
            command.Drawing = drawing;
            foreach(SeaCreature seacreature in command.Drawing.SeaCreatures)
                if (seacreature.IsSelected) prevSizes.Add(seacreature.Size);

            // Test undo with no previous drawing and a non-null object.
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
                    Assert.AreEqual(command.Drawing.SeaCreatures[i].Size.Width, 
                        prevSizes[j].Width * 0.5);
                    Assert.AreEqual(command.Drawing.SeaCreatures[i].Size.Height, 
                        prevSizes[j].Height * 0.5);
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
                    Assert.AreEqual(prevSizes[j].Height, 
                        command.Drawing.SeaCreatures[i].Size.Height);
                    Assert.AreEqual(prevSizes[j].Width, 
                        command.Drawing.SeaCreatures[i].Size.Width);
                    j++;
                }
            }
        }

        [TestMethod]
        public void ScaleSelectedCommandEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("scale");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SCALE"));
            command.Drawing = drawing;

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);
        }

        [TestMethod]
        public void ScaleSelectedCommandNullDrawingTest()
        {
            // Test that the command was created correctly.
            Command command = commandFactory.Create("scale");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SCALE"));
            command.Drawing = null;

            // Test undo with no previous drawing & a null Drawing object.
            Assert.IsFalse(command.Undo());

            // Test execute and undo with a null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Undo());
        }

        [TestMethod]
        public void ScaleSelectedCommandInputParametersTest()
        {
            // Test that the command was created correctly.
            drawingSetup(false);
            Command command = commandFactory.Create("scale", 3.0F);
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SCALE"));
            command.Drawing = drawing;

            // Test that the creature was set up correctly.
            command.Execute();
            SeaCreature creature = command.Drawing.SeaCreatures[0];
            Assert.AreEqual(60 * 3, creature.Size.Width);
            Assert.AreEqual(60 * 3, creature.Size.Height);

            // Tes same thing as above, except with no parameters passed into the create function.
            command = null;
            drawingSetup(false);
            command = commandFactory.Create("scale");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.EndsWith("SCALE"));
            command.Drawing = drawing;

            command.Execute();
            creature = command.Drawing.SeaCreatures[0];
            Assert.AreEqual(60, creature.Size.Width);
            Assert.AreEqual(60, creature.Size.Height);
        }
    }
}
