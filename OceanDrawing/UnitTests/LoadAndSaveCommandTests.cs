using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.CommandPattern.Commands;
using AppLayer.DrawingComponents.DrawingObjects;
using AppLayer.DrawingComponents;
using OceanDrawing;

namespace UnitTests
{
    [TestClass]
    public class LoadAndSaveCommandTests: CommandTests
    {
        [TestMethod]
        public void SaveAndLoadCommandNonEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(false);
            Command command = commandFactory.Create("save", "test1.json");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SAVE"));
            command.Drawing = drawing;

            // Test saving the command, then loading it back up.
            Assert.IsTrue(command.Execute());
            command = commandFactory.Create("load", "test1.json");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("LOAD"));
            command.Drawing = new Drawing() { Factory = seaCreatureFactory };
            Assert.IsTrue(command.Execute());

            // Test that the file was loaded correctly.
            Assert.AreEqual(drawing.Factory.getDictionarySize(), 
                command.Drawing.Factory.getDictionarySize());
            Assert.AreEqual(drawing.SeaCreatures.Count, command.Drawing.SeaCreatures.Count);
            Assert.AreEqual(1, drawing.SeaCreatures.Count);
            Assert.AreEqual(drawing.Selected?.IsSelected, command.Drawing.Selected?.IsSelected);
            Assert.AreEqual(drawing.Selected?.ActualCreature, command.Drawing.Selected?.ActualCreature);
            Assert.AreEqual(drawing.Selected?.Location.X, command.Drawing.Selected?.Location.X);
            Assert.AreEqual(drawing.Selected?.Location.Y, command.Drawing.Selected?.Location.Y);
            Assert.AreEqual(drawing.Selected?.Size.Height, command.Drawing.Selected?.Size.Height);
            Assert.AreEqual(drawing.Selected?.Size.Width, command.Drawing.Selected?.Size.Width);

            SeaCreature old = drawing.SeaCreatures[0];
            SeaCreature _new = command.Drawing.SeaCreatures[0];
            Assert.AreEqual(old.ActualCreature, _new.ActualCreature);
            Assert.AreEqual(old.IsSelected, _new.IsSelected);
            Assert.AreEqual(old.Location.X, _new.Location.X);
            Assert.AreEqual(old.Location.Y, _new.Location.Y);
            Assert.AreEqual(old.Size.Width, _new.Size.Width);
            Assert.AreEqual(old.Size.Height, _new.Size.Height);
        }

        [TestMethod]
        public void SaveAndLoadCommandEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("save", "test2.json");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SAVE"));
            command.Drawing = drawing;

            // Test correct behavior for execution with an empty drawing.
            Assert.IsTrue(command.Execute());
            command = commandFactory.Create("load", "test2.json");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("LOAD"));
            command.Drawing = new Drawing();
            Assert.IsTrue(command.Execute());
        }

        [TestMethod]
        public void SaveAndLoadCommandNullDrawingTest()
        {
            // Test that the command was created correctly.
            Command command = commandFactory.Create("save", "test3.json");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("SAVE"));
            command.Drawing = null;

            // Test correct behavior for execution with a null drawing.
            Assert.IsFalse(command.Execute());
            command = commandFactory.Create("load", "test3.json");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("LOAD"));
            Assert.IsFalse(command.Execute());
        }
    }
}
