using AppLayer.SudokuComponents;
using AppLayer.SolvingAlgorithms;
using System.Collections.Generic;
using System;
using System.IO;

namespace SudokuSolver
{
    class SudokuSolver
    {
        static PuzzleFactory factory;
        static Solver solver;

        static void SolvePuzzle(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File for puzzle doesn't exists.");
                return;
            }

            solver.Puzzle = factory.Create(file);
            solver.Techniques = new List<SolvingAlgorithm>()
            {
                new SolvedPuzzle() { Puzzle = solver.Puzzle },
                new NoPossibilities() { Puzzle = solver.Puzzle },
                new OnePossibility() { Puzzle = solver.Puzzle },
                new HiddenSolution() { Puzzle = solver.Puzzle },
                new TwinCellsCheck() { Puzzle = solver.Puzzle }
            };

            if (solver.Solve())
            {
                Console.WriteLine("Puzzle Solved.");
                Console.Write(solver.Puzzle.ToString());
                solver.Puzzle.WriteOutPuzzle();
            }
            else
            {
                Console.WriteLine("Puzzle couldn't be solved.");
                Console.Write(solver.Puzzle.ToString());

                foreach (Cell cell in solver.Puzzle)
                {
                    if (cell.Value == '-')
                    {
                        Console.WriteLine(cell.PossibilitiesToString());
                    }
                }
            }
        }

        static void SolvePuzzle(int puzzleSize, string file, string difficulty)
        {
            solver.Puzzle = factory.Create(file);
            solver.Techniques = new List<SolvingAlgorithm>()
            {
                new SolvedPuzzle() { Puzzle = solver.Puzzle },
                new NoPossibilities() { Puzzle = solver.Puzzle },
                new OnePossibility() { Puzzle = solver.Puzzle },
                new HiddenSolution() { Puzzle = solver.Puzzle },
                new TwinCellsCheck() { Puzzle = solver.Puzzle },
                new BruteForce() { Puzzle = solver.Puzzle }
            };

            Console.WriteLine("{0} {1}x{1}.", difficulty, puzzleSize);

            if (solver.Solve())
            {
                Console.WriteLine("Puzzle Solved.");
                Console.Write(solver.Puzzle.ToString());
                solver.Puzzle.WriteOutPuzzle();
            }
            else
            {
                Console.WriteLine("Puzzle couldn't be solved.");
                Console.Write(solver.Puzzle.ToString());

                foreach (Cell cell in solver.Puzzle)
                {
                    if (cell.Value == '-')
                    {
                        Console.WriteLine(cell.PossibilitiesToString());
                    }
                }
            }
        }

        static void SolveEasyToExpertPuzzles(List<string> files, int puzzleSize)
        {
            if (files.Count != 4) return;

            foreach (string file in files)
                if (!File.Exists(file)) return;

            SolvePuzzle(puzzleSize, files[0], "Easy");
            SolvePuzzle(puzzleSize, files[1], "Medium");
            SolvePuzzle(puzzleSize, files[2], "Hard");
            SolvePuzzle(puzzleSize, files[3], "Expert");
        }

        static void Main(string[] args)
        {
            bool keepGoing = false;
            string file;
            char response;
            factory = new PuzzleFactory();
            solver = new Solver();

            SolveEasyToExpertPuzzles(new List<string>() {
                "Puzzle-9x9-Easy-Sudoku.txt",
                "Puzzle-9x9-Medium-Sudoku.txt",
                "Puzzle-9x9-Hard-Sudoku.txt",
                "Puzzle-9x9-Expert-Sudoku.txt"
            }, 9);

            SolveEasyToExpertPuzzles(new List<string>() {
                "Puzzle-4x4-Easy-Sudoku.txt",
                "Puzzle-4x4-Medium-Sudoku.txt",
                "Puzzle-4x4-Hard-Sudoku.txt",
                "Puzzle-4x4-Expert-Sudoku.txt"
            }, 4);

            SolveEasyToExpertPuzzles(new List<string>() {
                "Puzzle-16x16-Easy-Sudoku.txt",
                "Puzzle-16x16-Medium-Sudoku.txt",
                "Puzzle-16x16-Hard-Sudoku.txt",
                "Puzzle-16x16-Expert-Sudoku.txt"
            }, 16);

            do
            {
                Console.Write("Would you like to try a different puzzle (Y/N)? ");
                response = Convert.ToChar(Console.Read());
                Console.ReadLine();

                if (char.ToUpper(response) == 'Y')
                {
                    keepGoing = true;
                    Console.Write("Please enter the name of the file for the puzzle: ");
                    file = Console.ReadLine();
                    SolvePuzzle(file);
                }
                else
                {
                    keepGoing = false;
                    break;
                }
            } while (keepGoing);
        }
    }
}
