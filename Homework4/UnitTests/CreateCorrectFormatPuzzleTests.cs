using AppLayer.SudokuComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CreateCorrectFormatPuzzleTests : CreatePuzzleTest
    {
        [TestMethod]
        public void CreateCorrectFormatFourByFourPuzzleTest()
        {
            // Create puzzle and ensure that the right number of rows, columns, and blocks were created.
            setup();
            puzzle = factory.Create("Puzzle-4x4-Test.txt");
            Assert.IsNotNull(puzzle);
            Assert.IsTrue(puzzle.Rows.Count == puzzle.Columns.Count);
            Assert.IsTrue(puzzle.Rows.Count == puzzle.Blocks.Count);
            Assert.AreEqual(4, puzzle.Rows.Count);
            Assert.AreEqual(4, puzzle.Symbols.Count);

            // Ensure that the symbols are the correct symbols.
            Assert.AreEqual('1', puzzle.Symbols[0]);
            Assert.AreEqual('2', puzzle.Symbols[1]);
            Assert.AreEqual('3', puzzle.Symbols[2]);
            Assert.AreEqual('4', puzzle.Symbols[3]);

            // Ensure that the rows, columns, and blocks were set up correctly.
            foreach (Row row in puzzle.Rows)
            {
                Assert.IsNotNull(row);
                Assert.IsNotNull(row.Cells);
                Assert.AreEqual(4, row.Cells.Count);
            }

            foreach (Column column in puzzle.Columns)
            {
                Assert.IsNotNull(column);
                Assert.IsNotNull(column.Cells);
                Assert.AreEqual(4, column.Cells.Count);
            }

            foreach (Block block in puzzle.Blocks)
            {
                Assert.IsNotNull(block);
                Assert.IsNotNull(block.Cells);
                Assert.AreEqual(4, block.Cells.Count);
            }
        }

        [TestMethod]
        public void CreateCorrectFormatNineByNinePuzzleTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-9x9-Test.txt");
            Assert.IsNotNull(puzzle);
            Assert.IsTrue(puzzle.Rows.Count == puzzle.Columns.Count);
            Assert.IsTrue(puzzle.Rows.Count == puzzle.Blocks.Count);
            Assert.AreEqual(9, puzzle.Rows.Count);
            Assert.AreEqual(9, puzzle.Symbols.Count);

            // Ensure that the symbols are the correct symbols.
            Assert.AreEqual('1', puzzle.Symbols[0]);
            Assert.AreEqual('2', puzzle.Symbols[1]);
            Assert.AreEqual('3', puzzle.Symbols[2]);
            Assert.AreEqual('4', puzzle.Symbols[3]);
            Assert.AreEqual('5', puzzle.Symbols[4]);
            Assert.AreEqual('6', puzzle.Symbols[5]);
            Assert.AreEqual('7', puzzle.Symbols[6]);
            Assert.AreEqual('8', puzzle.Symbols[7]);
            Assert.AreEqual('9', puzzle.Symbols[8]);

            // Ensure that the rows, columns, and blocks were set up correctly.
            foreach (Row row in puzzle.Rows)
            {
                Assert.IsNotNull(row);
                Assert.IsNotNull(row.Cells);
                Assert.AreEqual(9, row.Cells.Count);
            }

            foreach (Column column in puzzle.Columns)
            {
                Assert.IsNotNull(column);
                Assert.IsNotNull(column.Cells);
                Assert.AreEqual(9, column.Cells.Count);
            }

            foreach (Block block in puzzle.Blocks)
            {
                Assert.IsNotNull(block);
                Assert.IsNotNull(block.Cells);
                Assert.AreEqual(9, block.Cells.Count);
            }
        }

        [TestMethod]
        public void CreateCorrectFormatSixteenBySixteenPuzzleTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-16x16-Test.txt");
            Assert.IsNotNull(puzzle);
            Assert.IsTrue(puzzle.Rows.Count == puzzle.Columns.Count);
            Assert.IsTrue(puzzle.Rows.Count == puzzle.Blocks.Count);
            Assert.AreEqual(16, puzzle.Rows.Count);
            Assert.AreEqual(16, puzzle.Symbols.Count);

            // Ensure that the symbols are the correct symbols.
            Assert.AreEqual('1', puzzle.Symbols[0]);
            Assert.AreEqual('2', puzzle.Symbols[1]);
            Assert.AreEqual('3', puzzle.Symbols[2]);
            Assert.AreEqual('4', puzzle.Symbols[3]);
            Assert.AreEqual('5', puzzle.Symbols[4]);
            Assert.AreEqual('6', puzzle.Symbols[5]);
            Assert.AreEqual('7', puzzle.Symbols[6]);
            Assert.AreEqual('8', puzzle.Symbols[7]);
            Assert.AreEqual('9', puzzle.Symbols[8]);

            Assert.AreEqual('A', puzzle.Symbols[9]);
            Assert.AreEqual('B', puzzle.Symbols[10]);
            Assert.AreEqual('C', puzzle.Symbols[11]);
            Assert.AreEqual('D', puzzle.Symbols[12]);
            Assert.AreEqual('E', puzzle.Symbols[13]);
            Assert.AreEqual('F', puzzle.Symbols[14]);
            Assert.AreEqual('G', puzzle.Symbols[15]);

            // Ensure that the rows, columns, and blocks were set up correctly.
            foreach (Row row in puzzle.Rows)
            {
                Assert.IsNotNull(row);
                Assert.IsNotNull(row.Cells);
                Assert.AreEqual(16, row.Cells.Count);
            }

            foreach (Column column in puzzle.Columns)
            {
                Assert.IsNotNull(column);
                Assert.IsNotNull(column.Cells);
                Assert.AreEqual(16, column.Cells.Count);
            }

            foreach (Block block in puzzle.Blocks)
            {
                Assert.IsNotNull(block);
                Assert.IsNotNull(block.Cells);
                Assert.AreEqual(16, block.Cells.Count);
            }
        }

        [TestMethod]
        public void CreateCorrectFormatTwentyFiveByTwentyFivePuzzleTest()
        {
            setup();
            puzzle = factory.Create("Puzzle-25x25-Test.txt");
            Assert.IsNotNull(puzzle);
            Assert.IsTrue(puzzle.Rows.Count == puzzle.Columns.Count);
            Assert.IsTrue(puzzle.Rows.Count == puzzle.Blocks.Count);
            Assert.AreEqual(25, puzzle.Rows.Count);
            Assert.AreEqual(25, puzzle.Symbols.Count);

            // Ensure that the symbols are the correct symbols.
            Assert.AreEqual('1', puzzle.Symbols[0]);
            Assert.AreEqual('2', puzzle.Symbols[1]);
            Assert.AreEqual('3', puzzle.Symbols[2]);
            Assert.AreEqual('4', puzzle.Symbols[3]);
            Assert.AreEqual('5', puzzle.Symbols[4]);
            Assert.AreEqual('6', puzzle.Symbols[5]);
            Assert.AreEqual('7', puzzle.Symbols[6]);
            Assert.AreEqual('8', puzzle.Symbols[7]);
            Assert.AreEqual('9', puzzle.Symbols[8]);

            Assert.AreEqual('A', puzzle.Symbols[9]);
            Assert.AreEqual('B', puzzle.Symbols[10]);
            Assert.AreEqual('C', puzzle.Symbols[11]);
            Assert.AreEqual('D', puzzle.Symbols[12]);
            Assert.AreEqual('E', puzzle.Symbols[13]);
            Assert.AreEqual('F', puzzle.Symbols[14]);
            Assert.AreEqual('G', puzzle.Symbols[15]);
            Assert.AreEqual('H', puzzle.Symbols[16]);
            Assert.AreEqual('I', puzzle.Symbols[17]);
            Assert.AreEqual('J', puzzle.Symbols[18]);
            Assert.AreEqual('K', puzzle.Symbols[19]);
            Assert.AreEqual('L', puzzle.Symbols[20]);
            Assert.AreEqual('M', puzzle.Symbols[21]);
            Assert.AreEqual('N', puzzle.Symbols[22]);
            Assert.AreEqual('O', puzzle.Symbols[23]);
            Assert.AreEqual('P', puzzle.Symbols[24]);

            // Ensure that the rows, columns, and blocks were set up correctly.
            foreach (Row row in puzzle.Rows)
            {
                Assert.IsNotNull(row);
                Assert.IsNotNull(row.Cells);
                Assert.AreEqual(25, row.Cells.Count);
            }

            foreach (Column column in puzzle.Columns)
            {
                Assert.IsNotNull(column);
                Assert.IsNotNull(column.Cells);
                Assert.AreEqual(25, column.Cells.Count);
            }

            foreach (Block block in puzzle.Blocks)
            {
                Assert.IsNotNull(block);
                Assert.IsNotNull(block.Cells);
                Assert.AreEqual(25, block.Cells.Count);
            }
        }

        [TestMethod]
        public void CreateCorrectFormatThirtySixByThirtySixPuzzleTest()
        {

        }
    }
}
