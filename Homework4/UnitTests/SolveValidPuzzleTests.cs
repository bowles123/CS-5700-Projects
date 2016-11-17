using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.SolvingAlgorithms;

namespace UnitTests
{
    [TestClass]
    public class SolveValidPuzzleTests : SolvingAlgorithmsTest
    {
        [TestMethod]
        public void SolvedPuzzleSolveValidTest()
        {
            setup(4, new SolvedPuzzle());
            Assert.IsFalse(puzzle.Solved);
            Assert.IsFalse(changed);

            puzzle = factory.Create("Puzzle-4x4-Solved.txt");
            algorithm = new SolvedPuzzle();
            changed = algorithm.Execute();
            Assert.IsTrue(puzzle.Solved);
            Assert.IsFalse(changed);
        }

        [TestMethod]
        public void NoPossibilitiesSolveValidTest()
        {
            setup(4, new NoPossibilities());
        }

        [TestMethod]
        public void OnePossibilitySolveValidTest()
        {
            setup(4, new OnePossibility());
        }

        [TestMethod]
        public void PossibilityElliminationSolveValidTest()
        {
            setup(4, new PossibilityEllimination());
        }

        [TestMethod]
        public void BruteForceSolveValidTest()
        {
            setup(4, new BruteForce());
        }
    }
}
