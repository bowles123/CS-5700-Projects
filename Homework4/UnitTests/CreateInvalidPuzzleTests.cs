using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CreateInvalidPuzzleTests : PuzzleTest
    {
        [TestMethod]
        public void CreateInvalidNonSymmetricPuzzleTest()
        {
            setup();
            puzzle = factory.Create("Non-Symmetric-Puzzle.txt");
            Assert.IsNull(puzzle);
        }

        [TestMethod]
        public void CreateInvalidIncompleteSymbolsPuzzleTest()
        {
            setup();
            puzzle = factory.Create("Incomplete-Symbols-Puzzle");
            Assert.IsNull(puzzle);
        }

        [TestMethod]
        public void CreatePuzzleFromNonExistingFileTest()
        {
            setup();
            puzzle = factory.Create("");
            Assert.IsNull(puzzle);
        }
    }
}
