using AppLayer.SudokuComponents;
using System.Diagnostics;

namespace AppLayer.SolvingAlgorithms
{
    public abstract class SolvingAlgorithm
    {
        private Stopwatch stopwatch;
        private int solveTime;

        public Puzzle Puzzle { get; set; }
        public abstract void IteratePuzzle();

        public SolvingAlgorithm()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Start();
            IteratePuzzle();
        }

        public void End()
        {
            stopwatch.Stop();
            solveTime = stopwatch.Elapsed.Seconds;

            if (Puzzle.Solved)
                Puzzle.WriteOutPuzzle(Puzzle.OutFile);
        }

        public void UpdateCell(Cell cell, char val)
        {
            cell.Update(val);
            Puzzle.SolvingAlgorithm = new SolvedPuzzle();
            Puzzle.SolvingAlgorithm.Start();
        }
    }
}
