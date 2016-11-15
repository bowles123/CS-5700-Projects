using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.SudokuComponents;

namespace UnitTests
{
    [TestClass]
    public class CreateCorrectCompletPuzzleTests : CreatePuzzleTest
    {
        [TestMethod]
        public void CreateCorrectCompleteFourByFourPuzzleTest()
        {
            int block;
            setup();
            puzzle = factory.Create("Puzzle-4x4-Test.txt");
            Assert.IsNotNull(puzzle);
            Assert.IsNotNull(puzzle.Rows);
            Assert.IsNotNull(puzzle.Columns);
            Assert.IsNotNull(puzzle.Blocks);

            foreach (Row row in puzzle.Rows)
            {
                Assert.IsNotNull(row.Cells);

                foreach (Cell cell in row.Cells)
                {
                    Assert.IsNotNull(cell);
                    Assert.IsTrue(puzzle.Columns[cell.X - 1].Cells.Contains(cell));
                    Assert.AreEqual(cell.X, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].X);
                    Assert.AreEqual(cell.Y, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].Y);

                    block = ((cell.Y - 1) / 2) * 2 + (cell.X - 1) / 2;
                    Assert.IsTrue(puzzle.Blocks[block].Cells.Contains(cell));
                    Assert.AreEqual(cell.B, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].B);
                }
            }
        }

        [TestMethod]
        public void CreateCorrectCompleteNineByNinePuzzleTest()
        {
            int block;
            setup();
            puzzle = factory.Create("Puzzle-9x9-Test.txt");
            Assert.IsNotNull(puzzle);
            Assert.IsNotNull(puzzle.Rows);
            Assert.IsNotNull(puzzle.Columns);
            Assert.IsNotNull(puzzle.Blocks);

            foreach (Row row in puzzle.Rows)
            {
                Assert.IsNotNull(row.Cells);

                foreach (Cell cell in row.Cells)
                {
                    Assert.IsNotNull(cell);
                    Assert.IsTrue(puzzle.Columns[cell.X - 1].Cells.Contains(cell));
                    Assert.AreEqual(cell.X, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].X);
                    Assert.AreEqual(cell.Y, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].Y);

                    block = ((cell.Y - 1) / 3) * 3 + (cell.X - 1) / 3;
                    Assert.IsTrue(puzzle.Blocks[block].Cells.Contains(cell));
                    Assert.AreEqual(cell.B, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].B);
                }
            }
        }

        [TestMethod]
        public void CreateCorrectCompleteSixteenBySixteenPuzzleTest()
        {
            int block;
            setup();
            puzzle = factory.Create("Puzzle-16x16-Test.txt");
            Assert.IsNotNull(puzzle);
            Assert.IsNotNull(puzzle.Rows);
            Assert.IsNotNull(puzzle.Columns);
            Assert.IsNotNull(puzzle.Blocks);

            foreach (Row row in puzzle.Rows)
            {
                Assert.IsNotNull(row.Cells);

                foreach (Cell cell in row.Cells)
                {
                    Assert.IsNotNull(cell);
                    Assert.IsTrue(puzzle.Columns[cell.X - 1].Cells.Contains(cell));
                    Assert.AreEqual(cell.X, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].X);
                    Assert.AreEqual(cell.Y, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].Y);

                    block = ((cell.Y - 1) / 4) * 4 + (cell.X - 1) / 4;
                    Assert.IsTrue(puzzle.Blocks[block].Cells.Contains(cell));
                    Assert.AreEqual(cell.B, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].B);
                }
            }
        }

        [TestMethod]
        public void CreateCorrectCompleteTwentyFiveByTwentyFivePuzzleTest()
        {
            int block;
            setup();
            puzzle = factory.Create("Puzzle-25x25-Test.txt");
            Assert.IsNotNull(puzzle);
            Assert.IsNotNull(puzzle.Rows);
            Assert.IsNotNull(puzzle.Columns);
            Assert.IsNotNull(puzzle.Blocks);

            foreach (Row row in puzzle.Rows)
            {
                Assert.IsNotNull(row.Cells);

                foreach (Cell cell in row.Cells)
                {
                    Assert.IsNotNull(cell);
                    Assert.IsTrue(puzzle.Columns[cell.X - 1].Cells.Contains(cell));
                    Assert.AreEqual(cell.X, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].X);
                    Assert.AreEqual(cell.Y, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].Y);

                    block = ((cell.Y - 1) / 5) * 5 + (cell.X - 1) / 5;
                    Assert.IsTrue(puzzle.Blocks[block].Cells.Contains(cell));
                    Assert.AreEqual(cell.B, puzzle.Rows[cell.Y - 1].Cells[cell.X - 1].B);
                }
            }
        }

        [TestMethod]
        public void CreateCorrectCompleteThirtySixByThirtySixPuzzleTest()
        {

        }
    }
}
