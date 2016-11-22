using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.SolvingAlgorithms;

namespace UnitTests
{
    [TestClass]
    public class SolvingAlgorithmTests : SolvingAlgorithmsTest
    {
        [TestMethod]
        public void SolvedPuzzleSolveValidTest()
        {
            setup(4, new SolvedPuzzle());
            Assert.IsFalse(puzzle.Solved);
            Assert.IsFalse(changed);

            puzzle = factory.Create("Puzzle-4x4-Solved.txt");
            algorithm = new SolvedPuzzle();
            algorithm.Puzzle = puzzle;
            changed = algorithm.Execute();
            Assert.IsTrue(puzzle.Solved);
            Assert.IsFalse(changed);
        }

        [TestMethod]
        public void NoPossibilitiesSolveValidTest()
        {
            setup(4, new NoPossibilities());
            Assert.IsFalse(puzzle.Solved);
            Assert.IsTrue(puzzle.Invalid);
            Assert.IsFalse(changed);
        }

        [TestMethod]
        public void OnePossibilitySolveValidTest()
        {
            setup(4, new OnePossibility());
            Assert.IsFalse(puzzle.Solved);
            Assert.IsTrue(changed);
        }

        [TestMethod]
        public void PossibilityElliminationSolveValidTest()
        {
            setup(4, new PossibilityEllimination());
            Assert.IsFalse(puzzle.Solved);
            Assert.IsFalse(changed);
        }

        [TestMethod]
        public void TwinCellsCheckSolveValidTest()
        {
            setup(4, new TwinCellsCheck());
            Assert.IsFalse(puzzle.Solved);
            Assert.IsFalse(changed);
        }

        [TestMethod]
        public void BruteForceSolveValidTest()
        {
            setup(4, new BruteForce());
            Assert.IsFalse(puzzle.Solved);
            Assert.IsTrue(changed);
        }
    }
}
