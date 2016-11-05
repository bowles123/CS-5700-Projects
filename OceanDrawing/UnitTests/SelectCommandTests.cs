using AppLayer.CommandPattern.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OceanDrawing;
using AppLayer.DrawingComponents;

namespace UnitTests
{
    [TestClass]
    public class SelectCommandTests: CommandTests
    {
        public void SelectCommandWithNonEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(false);
            Command command = commandFactory.Create("select", seacreature.Location);
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SELECT"));
            command.Drawing = drawing;

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            Assert.IsTrue(command.Execute());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(1, command.Drawing.SeaCreatures.Count);
            Assert.AreEqual(!seacreature.IsSelected, command.Drawing.SeaCreatures[0].IsSelected);
            command.Drawing.IsDirty = false;

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsTrue(command.Undo());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(1, command.Drawing.SeaCreatures.Count);
            Assert.AreEqual(seacreature.IsSelected, command.Drawing.SeaCreatures[0].IsSelected);
        }

        [TestMethod]
        public void SelectCommandEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("select");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SELECT"));
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
        public void SelectCommandNullDrawingTest()
        {
            // Test that the command was created correctly.
            Command command = commandFactory.Create("select");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SELECT"));
            command.Drawing = null;

            // Test undo with no previous drawing & a null Drawing object.
            Assert.IsFalse(command.Undo());

            // Test execute and undo with a null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Undo());
        }
    }
}
