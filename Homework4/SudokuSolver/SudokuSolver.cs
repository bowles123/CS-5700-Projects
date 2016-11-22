using AppLayer.SudokuComponents;
using AppLayer.SolvingAlgorithms;
using System.Collections.Generic;
using System;

namespace SudokuSolver
{
    class SudokuSolver
    {
        static void Main(string[] args)
        {
            PuzzleFactory factory = new PuzzleFactory();
            Solver solver = new Solver();
            solver.Puzzle = factory.Create("Puzzle-4x4-0001.txt");

            solver.Techniques = new List<SolvingAlgorithm>()
            {
                new SolvedPuzzle() { Puzzle = solver.Puzzle },
                new NoPossibilities() { Puzzle = solver.Puzzle },
                new OnePossibility() { Puzzle = solver.Puzzle },
                new PossibilityEllimination() { Puzzle = solver.Puzzle },
                new TwinCellsCheck() { Puzzle = solver.Puzzle }
            };

            Console.WriteLine("Easy 4x4.");

            if (solver.Solve())
                Console.WriteLine("Puzzle Solved.");
        }
    }
}
