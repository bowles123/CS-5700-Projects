using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.CommandPattern.Commands;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Collections.Generic;
using AppLayer.DrawingComponents;
using OceanDrawing;

namespace UnitTests
{
    [TestClass]
    public class DeselectAllCommandTests: CommandTests
    {
        [TestMethod]
        public void DeselectAllCommandNonEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(true);
            List<SeaCreature> wasSelected = new List<SeaCreature>();
            Command command = commandFactory.Create("deselect");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("DESELECT"));
            command.Drawing = drawing;
            foreach (SeaCreature seaCreature in command.Drawing.SeaCreatures)
                if (seaCreature.IsSelected) wasSelected.Add(seaCreature);

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            Assert.IsTrue(command.Execute());
            Assert.IsTrue(command.Drawing.IsDirty);
            foreach (SeaCreature c in command.Drawing.SeaCreatures)
                Assert.IsFalse(c.IsSelected);
            command.Drawing.IsDirty = false;

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsTrue(command.Undo());
            Assert.IsTrue(command.Drawing.IsDirty);
            foreach (SeaCreatureWithAllState s in command.Drawing.SeaCreatures)
                foreach (SeaCreatureWithAllState sc in wasSelected)
                    if (s.CreatureId == sc.CreatureId) Assert.IsTrue(s.IsSelected);
        }

        [TestMethod]
        public void DeselectAllCommandWithEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            List<SeaCreature> wasSelected = new List<SeaCreature>();
            Command command = commandFactory.Create("deselect");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("DESELECT"));
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
        public void DeselectAllCommandNullDrawingTest()
        {
            // Test that the command was created correctly.
            Command command = commandFactory.Create("deselect");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("DESELECT"));
            command.Drawing = null;

            // Test undo with no previous drawing & a null Drawing object.
            Assert.IsFalse(command.Undo());

            // Test execute and undo with a null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Undo());
        }
    }
}
