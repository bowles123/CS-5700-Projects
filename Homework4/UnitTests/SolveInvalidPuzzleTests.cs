using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AppLayer.SolvingAlgorithms;

namespace UnitTests
{
    [TestClass]
    public class SolveInvalidPuzzleTests : PuzzleTest
    {
        [TestMethod]
        public void NoPossibilitiesForEmptyCellTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-4x4-Test.txt");
            puzzle.Solve(new List<SolvingAlgorithm>() {
                new SolvedPuzzle() { Puzzle = puzzle },
                new NoPossibilities() { Puzzle = puzzle }
            });

            Assert.IsFalse(puzzle.Solved);
            Assert.IsTrue(puzzle.Invalid);
            Assert.AreEqual(0, puzzle.Solutions);
        }

        [TestMethod]
        public void MultipleSolutionsTest()
        {

        }
    }
}
