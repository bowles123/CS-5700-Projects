using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.CommandPattern.Commands;
using AppLayer.DrawingComponents;
using OceanDrawing;

namespace UnitTests
{
    [TestClass]
    public class NewCommandTests: CommandTests
    {
        [TestMethod]
        public void NewCommandNonEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(false);
            Command command = commandFactory.Create("new");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("NEW"));
            command.Drawing = drawing;

            // Test undo with no previous drawing & a non-null Drawing object.
            command.Undo();
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            command.Execute();
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(0, command.Drawing.SeaCreatures?.Count);
            command.Drawing.IsDirty = false;

            // Test undo with a previous drawing & a non-null Drawing object.
            command.Undo();
            Assert.IsFalse(command.Drawing.IsDirty);
        }

        [TestMethod]
        public void NewCommandEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("new");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("NEW"));
            command.Drawing = drawing;

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            Assert.IsTrue(command.Execute());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(0, command.Drawing.SeaCreatures?.Count);

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
        }

        [TestMethod]
        public void NewCommandNullDrawingTest()
        {
            // Test that the command was created correctly.
            Command command = commandFactory.Create("new");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("NEW"));
            command.Drawing = null;

            // Test undo with no previous drawing & a null Drawing object.
            Assert.IsFalse(command.Undo());

            // Test execute and undo with a null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Undo());
        }
    }
}
