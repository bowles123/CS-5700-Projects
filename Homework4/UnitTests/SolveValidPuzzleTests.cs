using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AppLayer.SolvingAlgorithms;
using AppLayer.SudokuComponents;
using SudokuSolver;

namespace UnitTests
{
    [TestClass]
    public class SolveValidPuzzleTests : PuzzleTest
    {
        [TestMethod]
        public void SolveEasyFourByFourTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-4x4-Valid.txt");
            puzzle.Solve(new List<SolvingAlgorithm>() {
                new SolvedPuzzle() { Puzzle = puzzle }, 
                new NoPossibilities() { Puzzle = puzzle },
                new OnePossibility() { Puzzle = puzzle }
            });

            Assert.IsTrue(puzzle.Solved);
            Assert.AreEqual(1, puzzle.Solutions);
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
        public void SolveDifficultFourByFourTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-Difficult-4x4-Test.txt");
            puzzle.Solve(new List<SolvingAlgorithm>() {
                new SolvedPuzzle() { Puzzle = puzzle },
                new NoPossibilities() { Puzzle = puzzle },
                new OnePossibility() { Puzzle = puzzle }
            });

            Assert.IsTrue(puzzle.Solved);
            Assert.AreEqual(1, puzzle.Solutions);
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
        public void SolveEasyNineByNineTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-Easy-9x9-Test.txt");
            puzzle.Solve(new List<SolvingAlgorithm>() {
                new SolvedPuzzle() { Puzzle = puzzle },
                new NoPossibilities() { Puzzle = puzzle },
                new OnePossibility() { Puzzle = puzzle }
            });

            Assert.IsTrue(puzzle.Solved);
            Assert.AreEqual(1, puzzle.Solutions);
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
        public void SolveDifficultNineByNineTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-Difficult-9x9-Test.txt");
            puzzle.Solve(new List<SolvingAlgorithm>() {
                new SolvedPuzzle() { Puzzle = puzzle },
                new NoPossibilities() { Puzzle = puzzle },
                new OnePossibility() { Puzzle = puzzle },
                new PossibilityEllimination() { Puzzle = puzzle },
                new TwinCellsCheck() { Puzzle = puzzle }
            });

            Assert.IsTrue(puzzle.Solved);
            Assert.AreEqual(1, puzzle.Solutions);
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
        public void SolveEasySixteenBySixteenTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-Easy-16x16-Test.txt");
            puzzle.Solve(new List<SolvingAlgorithm>() {
                new SolvedPuzzle() { Puzzle = puzzle },
                new NoPossibilities() { Puzzle = puzzle },
                new OnePossibility() { Puzzle = puzzle }
            });

            Assert.IsTrue(puzzle.Solved);
            Assert.AreEqual(1, puzzle.Solutions);
            Assert.IsFalse(puzzle.Invalid);
            puzzle.WriteOutPuzzle();

            foreach (Cell cell in puzzle)
            {
                Assert.AreNotEqual('-', cell);
                Assert.AreEqual(0, cell.Possibilities.Count);
                Assert.IsTrue(puzzle.Symbols.Contains(cell.Value));
            }
        }

        //[TestMethod]
        //public void SolveDifficultSixteenBySixteenTest()
        //{
        //    setup();
        //    puzzle = factory.Create("Puzzle-Difficult-16x16-Test.txt");
        //    Solver solver = new Solver()
        //    {
        //        Puzzle = puzzle,
        //        Techniques = new List<SolvingAlgorithm>() {
        //            new SolvedPuzzle() { Puzzle = puzzle },
        //            new NoPossibilities() { Puzzle = puzzle },
        //            new OnePossibility() { Puzzle = puzzle },
        //            new PossibilityEllimination() { Puzzle = puzzle },
        //            new TwinCellsCheck() { Puzzle = puzzle },
        //            new BruteForce() { Puzzle = puzzle }
        //        }
        //    };

        //    solver.Solve();
        //    Assert.IsTrue(puzzle.Solved);
        //    Assert.AreEqual(1, puzzle.Solutions);
        //    Assert.IsFalse(puzzle.Invalid);
        //    puzzle.WriteOutPuzzle();

        //    foreach (Cell cell in puzzle)
        //    {
        //        Assert.AreNotEqual('-', cell);
        //        Assert.AreEqual(0, cell.Possibilities.Count);
        //        Assert.IsTrue(puzzle.Symbols.Contains(cell.Value));
        //    }
        //}

        //[TestMethod]
        //public void SolveEasyTwentyFiveByTwentyFiveTest()
        //{
        //    setup();
        //    puzzle = factory.Create("Puzzle-Easy-25x25-Test.txt");
        //    puzzle.Solve(new List<SolvingAlgorithm>() {
        //        new SolvedPuzzle() { Puzzle = puzzle },
        //        new NoPossibilities() { Puzzle = puzzle },
        //        new OnePossibility() { Puzzle = puzzle },
        //        new PossibilityEllimination() { Puzzle = puzzle },
        //        new TwinCellsCheck() { Puzzle = puzzle },
        //        new BruteForce() { Puzzle = puzzle }
        //    });

        //    Assert.IsTrue(puzzle.Solved);
        //    Assert.AreEqual(1, puzzle.Solutions);
        //    Assert.IsFalse(puzzle.Invalid);
        //    puzzle.WriteOutPuzzle();

        //    foreach (Cell cell in puzzle)
        //    {
        //        Assert.AreNotEqual('-', cell);
        //        Assert.AreEqual(0, cell.Possibilities.Count);
        //        Assert.IsTrue(puzzle.Symbols.Contains(cell.Value));
        //    }
        //}
    }
}
