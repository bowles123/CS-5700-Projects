using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AppLayer.SolvingAlgorithms;
using AppLayer.SudokuComponents;
using SudokuSolver;

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
        public void SolveMultipleSolutionsFourByFourTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-Multiple-4x4-Test.txt");
            Solver solver = new Solver()
            {
                Puzzle = puzzle,
                Techniques = new List<SolvingAlgorithm>() {
                    new SolvedPuzzle() { Puzzle = puzzle },
                    new NoPossibilities() { Puzzle = puzzle },
                    new OnePossibility() { Puzzle = puzzle },
                    new HiddenSolution() { Puzzle = puzzle },
                    new TwinCellsCheck() { Puzzle = puzzle },
                    new BruteForce() { Puzzle = puzzle }
                }
            };

            solver.Solve();
            Assert.IsTrue(puzzle.Solved);
            Assert.AreEqual(2, puzzle.Solutions);
            Assert.IsFalse(puzzle.Invalid);
            puzzle.WriteOutPuzzle();

            foreach (Cell cell in puzzle)
            {
                Assert.AreNotEqual('-', cell);
                Assert.AreEqual(0, cell.Possibilities.Count);
                Assert.IsTrue(puzzle.Symbols.Contains(cell.Value));
            }
        }

        [TestMethod]
        public void SolveMultipleSolutionsSixteenBySixteenTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-Multiple-16x16-Test.txt");
            Solver solver = new Solver()
            {
                Puzzle = puzzle,
                Techniques = new List<SolvingAlgorithm>() {
                    new SolvedPuzzle() { Puzzle = puzzle },
                    new NoPossibilities() { Puzzle = puzzle },
                    new OnePossibility() { Puzzle = puzzle },
                    new HiddenSolution() { Puzzle = puzzle },
                    new TwinCellsCheck() { Puzzle = puzzle },
                    new BruteForce() { Puzzle = puzzle }
                }
            };

            solver.Solve();
            Assert.IsTrue(puzzle.Solved);
            Assert.AreEqual(2, puzzle.Solutions);
            Assert.IsFalse(puzzle.Invalid);
            puzzle.WriteOutPuzzle();

            foreach (Cell cell in puzzle)
            {
                Assert.AreNotEqual('-', cell);
                Assert.AreEqual(0, cell.Possibilities.Count);
                Assert.IsTrue(puzzle.Symbols.Contains(cell.Value));
            }
        }

        [TestMethod]
        public void SolveMultipleSolutionsTwentyFiveByTwentyFiveTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-Multiple-25x25-Test.txt");
            Solver solver = new Solver()
            {
                Puzzle = puzzle,
                Techniques = new List<SolvingAlgorithm>() {
                    new SolvedPuzzle() { Puzzle = puzzle },
                    new NoPossibilities() { Puzzle = puzzle },
                    new OnePossibility() { Puzzle = puzzle },
                    new HiddenSolution() { Puzzle = puzzle },
                    new TwinCellsCheck() { Puzzle = puzzle },
                    new BruteForce() { Puzzle = puzzle }
                }
            };

            solver.Solve();
            Assert.IsTrue(puzzle.Solved);
            Assert.AreEqual(2, puzzle.Solutions);
            Assert.IsFalse(puzzle.Invalid);
            puzzle.WriteOutPuzzle();

            foreach (Cell cell in puzzle)
            {
                Assert.AreNotEqual('-', cell);
                Assert.AreEqual(0, cell.Possibilities.Count);
                Assert.IsTrue(puzzle.Symbols.Contains(cell.Value));
            }
        }
    }
}
