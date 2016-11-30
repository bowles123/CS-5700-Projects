using AppLayer.SudokuComponents;

namespace UnitTests
{
    public class CreatePuzzleTest
    {
        protected PuzzleFactory factory;
        protected Puzzle puzzle;

        protected void setup()
        {
            factory = new PuzzleFactory();
        }
    }
}
