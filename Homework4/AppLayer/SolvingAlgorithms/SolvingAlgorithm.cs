using AppLayer.SudokuComponents;
using System.Diagnostics;

namespace AppLayer.SolvingAlgorithms
{
    public class SolvingAlgorithm
    {
        private Puzzle puzzle;
        private Stopwatch stopWatch;
        private int solveTime;

        public SolvingAlgorithm()
        {
            stopWatch = new Stopwatch();
        }

        public void Start()
        {
            stopWatch.Start();
        }

        public void End()
        {
            stopWatch.Stop();
            solveTime = stopWatch.Elapsed.Seconds;
        }

        public virtual void IteratePuzzle()
        {

        }

        public virtual void UpdateCell()
        {

        }
    }
}
