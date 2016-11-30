using AppLayer.SolvingAlgorithms;
using AppLayer.SudokuComponents;

namespace UnitTests
{
    public class SolvingAlgorithmsTest
    {
        protected SolvingAlgorithm algorithm;
        protected PuzzleFactory factory;
        protected Puzzle puzzle;
        protected bool changed;

        public void setup(int size, SolvingAlgorithm algorithm)
        {
            factory = new PuzzleFactory();
            puzzle = factory.Create(string.Format("Puzzle-{0}x{0}-Test.txt", size));
            this.algorithm = algorithm;
            algorithm.Puzzle = puzzle;
            changed = algorithm.Execute();
        }
    }
}
