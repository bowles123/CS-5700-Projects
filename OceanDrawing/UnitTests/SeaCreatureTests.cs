using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.DrawingComponents.DrawingObjects;
using System.Drawing;
using OceanDrawing;

namespace UnitTests
{
    [TestClass]
    public class SeaCreatureTests
    {
        private SeaCreatureFactory factory = new SeaCreatureFactory()
        { ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png", ReferenceType = typeof(OceanDrawingProgram) };
        private ExtrinsicSeaCreature extrinsicState = null;
        private SeaCreature creature;
        private int sizeBefore;

        private void setup(bool existing)
        {
            extrinsicState = new ExtrinsicSeaCreature()
            { CreatureType = "Shark", IsSelected = false, Location = new Point(3, 3), Size = new Size(1, 1) };

            if (existing)
            {
                factory.Create(extrinsicState);
            }

            sizeBefore = factory.getDictionarySize();
            creature = factory.Create(extrinsicState);
        }

        [TestMethod]
        public void CreateNullExtrinsicStateTest()
        {
            extrinsicState = null;
            sizeBefore = factory.getDictionarySize();
            creature = factory.Create(extrinsicState);
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.IsNull(creature);
        }

        [TestMethod]
        public void CreateWithExistingInstrinsicState()
        {
            setup(true);
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.AreEqual(extrinsicState.CreatureType, creature.ActualCreature);
            Assert.AreEqual(extrinsicState.IsSelected, creature.IsSelected);
            Assert.AreEqual(extrinsicState.Location.Y, creature.Location.Y);
            Assert.AreEqual(extrinsicState.Location.X, creature.Location.X);
            Assert.AreEqual(extrinsicState.Size.Height, creature.Size.Height);
            Assert.AreEqual(extrinsicState.Size.Width, creature.Size.Width);
        }

        [TestMethod]
        public void CreateAllCreatureTypesTest()
        {
            setup(false);
            sizeBefore++;
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.AreEqual("Shark", creature.ActualCreature);

            extrinsicState.CreatureType = "Dolphin";
            creature = factory.Create(extrinsicState);
            sizeBefore++;
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.AreEqual("Dolphin", creature.ActualCreature);

            extrinsicState.CreatureType = "Catfish";
            creature = factory.Create(extrinsicState);
            sizeBefore++;
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.AreEqual("Catfish", creature.ActualCreature);

            extrinsicState.CreatureType = "Whale";
            creature = factory.Create(extrinsicState);
            sizeBefore++;
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.AreEqual("Whale", creature.ActualCreature);

            extrinsicState.CreatureType = "Seahorse";
            creature = factory.Create(extrinsicState);
            sizeBefore++;
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.AreEqual("Seahorse", creature.ActualCreature);

            extrinsicState.CreatureType = "Seaturtle";
            creature = factory.Create(extrinsicState);
            sizeBefore++;
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.AreEqual("Seaturtle", creature.ActualCreature);

            extrinsicState.CreatureType = "Trout";
            creature = factory.Create(extrinsicState);
            sizeBefore++;
            Assert.AreEqual(sizeBefore, factory.getDictionarySize());
            Assert.AreEqual("Trout", creature.ActualCreature);
        }
    }
}
