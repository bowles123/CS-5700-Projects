using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.CommandPattern.Commands;
using AppLayer.DrawingComponents.DrawingObjects;
using AppLayer.DrawingComponents;
using System.Drawing;
using OceanDrawing;

namespace UnitTests
{
    [TestClass]
    public class AddSeaCreatureCommandTests: CommandTests
    {
        [TestMethod]
        public void AddSeaCreatureCommandNonEmptryDrawingTest()
        {
            // Test that the command was created correctly.
            drawingSetup(false);
            Command command = commandFactory.Create("add", "Shark");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("ADD"));
            command.Drawing = drawing;

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            Assert.IsTrue(command.Execute());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(2, command.Drawing.SeaCreatures?.Count);

            SeaCreature creature = command.Drawing.SeaCreatures[1];
            Assert.AreEqual(-40, creature.Location.X);
            Assert.AreEqual(-40, creature.Location.Y);
            Assert.AreEqual(80, creature.Size.Height);
            Assert.AreEqual(80, creature.Size.Width);
            command.Drawing.IsDirty = false;

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsTrue(command.Undo());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(1, command.Drawing.SeaCreatures?.Count);

            // Assert that the sea creature is the original sea creature.
            creature = command.Drawing.SeaCreatures[0];
            Assert.AreEqual(seacreature.IsSelected, creature.IsSelected);
            Assert.AreEqual(seacreature.ActualCreature, creature.ActualCreature);
            Assert.AreEqual(seacreature.Location.X, creature.Location.X);
            Assert.AreEqual(seacreature.Location.Y, creature.Location.Y);
            Assert.AreEqual(seacreature.Size.Width, creature.Size.Width);
            Assert.AreEqual(seacreature.Size.Width, creature.Size.Width);
        }

        [TestMethod]
        public void AddSeaCreatureCommandEmptyDrawingTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("add", "Dolphin");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("ADD"));
            command.Drawing = drawing;

            // Test undo with no previous drawing & a non-null Drawing object.
            Assert.IsFalse(command.Undo());
            Assert.IsFalse(command.Drawing.IsDirty);

            // Test execute with a non-null Drawing object.
            Assert.IsTrue(command.Execute());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(1, command.Drawing.SeaCreatures?.Count);

            // Test undo with a previous drawing & a non-null Drawing object.
            Assert.IsTrue(command.Undo());
            Assert.IsTrue(command.Drawing.IsDirty);
            Assert.AreEqual(0, command.Drawing.SeaCreatures?.Count);
        }

        [TestMethod]
        public void AddSeaCreatureCommandNullDrawingTest()
        {
            // Test that the command was created correctly.
            Command command = commandFactory.Create("add", "Catfish");
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("ADD"));
            command.Drawing = null;

            // Test execute and undo with null Drawing object.
            Assert.IsFalse(command.Execute());
            Assert.IsFalse(command.Undo());
        }

        [TestMethod]
        public void AddSeaCreatureCommandTwoInputsTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("add", "Dolphin", new Point(5, 4));
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("ADD"));
            command.Drawing = drawing;

            // Test that the drawings sea creatures are correct.
            Assert.IsTrue(command.Execute());
            Assert.AreEqual(1, command.Drawing.SeaCreatures.Count);
            SeaCreature creature = command.Drawing.SeaCreatures[0];
            Assert.IsTrue(creature.ActualCreature.Equals("Dolphin"));
            Assert.AreEqual(80, creature.Size.Width);
            Assert.AreEqual(80, creature.Size.Height);
            Assert.AreEqual((5 - creature.Size.Width / 2), creature.Location.X);
            Assert.AreEqual((4 - creature.Size.Height / 2), creature.Location.Y);
        }

        [TestMethod]
        public void AddSeaCreatureCommandThreeInputsTest()
        {
            // Test that the command was created correctly.
            drawing = new Drawing() { Factory = new SeaCreatureFactory()
            { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) } };
            Command command = commandFactory.Create("add", "Dolphin", new Point(5, 4), 2.0F);
            Assert.IsNotNull(command);
            Assert.IsTrue(command.ActualCommand.Equals("ADD"));
            command.Drawing = drawing;

            // Test that the drawings sea creatures are correct.
            Assert.IsTrue(command.Execute());
            Assert.AreEqual(1, command.Drawing.SeaCreatures.Count);
            SeaCreature creature = command.Drawing.SeaCreatures[0];
            Assert.IsTrue(creature.ActualCreature.Equals("Dolphin"));
            Assert.AreEqual(160, creature.Size.Height);
            Assert.AreEqual(160, creature.Size.Width);
            Assert.AreEqual((5 - creature.Size.Width / 2), creature.Location.X);
            Assert.AreEqual((4 - creature.Size.Height / 2), creature.Location.Y);
        }
    }
}
