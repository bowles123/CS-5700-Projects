using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.CommandPattern.Commands;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Collections.Generic;
using AppLayer.DrawingComponents;
using OceanDrawing;

namespace UnitTests
{
    [TestClass]
    public class RemoveSelectedCommandTests: CommandTests
    {
        [TestMethod]
        public void RemoveSelectedCommandWithNonEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(true);
            int prevCount;
            List<SeaCreature> existed = new List<SeaCreature>();
            Command command = commandFactory.Create("remove");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("REMOVE"));
            command.Drawing = drawing;
            foreach (SeaCreature seaCreature in command.Drawing.SeaCreatures)
                if (seaCreature.IsSelected) existed.Add(seaCreature);

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            prevCount = command.Drawing.SeaCreatures.Count;
            Assert.IsTrue(command.Execute());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(prevCount - existed.Count, command.Drawing.SeaCreatures.Count);
            command.Drawing.IsDirty = false;

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsTrue(command.Undo());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(prevCount, command.Drawing.SeaCreatures.Count);
        }

        [TestMethod]
        public void RemoveSelectedCommandEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            List<SeaCreature> existed = new List<SeaCreature>();
            Command command = commandFactory.Create("remove");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("REMOVE"));
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
        public void RemoveSelectedCommandNullDrawingTest()
        {
            // Test that the command was created correctly.
            List<SeaCreature> existed = new List<SeaCreature>();
            Command command = commandFactory.Create("remove");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("REMOVE"));
            command.Drawing = null;

            // Test undo with no previous drawing & a null Drawing object.
            Assert.IsFalse(command.Undo());

            // Test execute and undo with a null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Undo());
        }
    }
}
