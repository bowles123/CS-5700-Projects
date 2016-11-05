using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.CommandPattern.Commands;
using AppLayer.DrawingComponents.DrawingObjects;
using AppLayer.DrawingComponents;
using OceanDrawing;

namespace UnitTests
{
    [TestClass]
    public class DuplicateSelectedCommandTests: CommandTests
    {
        [TestMethod]
        public void DuplicateSelectedCommanWithNonEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(true);
            Command command = commandFactory.Create("duplicate");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("DUPLICATE"));
            DuplicateSelectedCommand d = command as DuplicateSelectedCommand;
            d.Factory = drawing.Factory;
            command.Drawing = drawing;

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            Assert.IsTrue(command.Execute());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(5, command.Drawing.SeaCreatures?.Count);

            // Assert that each selected sea creature was duplicated.
            for (int i = 0, j = 3; j < command.Drawing.SeaCreatures.Count; i++)
            {
                SeaCreature creature1 = command.Drawing.SeaCreatures[i];

                if (creature1.IsSelected)
                {
                    SeaCreature creature2 = command.Drawing.SeaCreatures[j++];
                    Assert.AreEqual(creature1.ActualCreature, creature2.ActualCreature);
                    Assert.AreEqual(creature1.IsSelected, creature2.IsSelected);
                    Assert.AreEqual(creature1.Location.X + creature1.Size.Width, creature2.Location.X);
                    Assert.AreEqual(creature1.Location.Y, creature2.Location.Y);
                    Assert.AreEqual(creature1.Size.Width, creature2.Size.Width);
                    Assert.AreEqual(creature1.Size.Height, creature2.Size.Height);
                }
            }
            command.Drawing.IsDirty = false;

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsTrue(command.Undo());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(3, command.Drawing.SeaCreatures?.Count);
        }

        [TestMethod]
        public void DuplicateSelectedEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("duplicate");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("DUPLICATE"));
            DuplicateSelectedCommand d = command as DuplicateSelectedCommand;
            d.Factory = drawing.Factory;
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
        public void DuplicateSelectedNullDrawingTest()
        {
            // Test that the command was created correctly.
            Command command = commandFactory.Create("duplicate");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("DUPLICATE"));
            command.Drawing = null;

            // Test undo with no previous drawing & a null Drawing object.
            Assert.IsFalse(command.Undo());

            // Test execute and undo with a null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Undo());
        }
    }
}
