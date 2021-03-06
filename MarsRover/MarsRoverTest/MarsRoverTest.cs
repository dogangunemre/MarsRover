using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTest
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void TestScanrio_12N_LMLMLMLMM()
        {
            Position position = new Position()
            {
                X = 1,
                Y = 2,
                Instruction = Instructions.N
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "LMLMLMLMM";

            position.StartMoving(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Instruction.ToString()}";
            var expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestScanrio_12N_LM()
        {
            Position position = new Position()
            {
                X = 1,
                Y = 2,
                Instruction = Instructions.N
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "LM";

            position.StartMoving(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Instruction.ToString()}";
            var expectedOutput = "1 3 N";

            Assert.AreNotEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestScanrio_33E_MRRMMRMRRM()
        {
            Position position = new Position()
            {
                X = 3,
                Y = 3,
                Instruction = Instructions.E
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "MRRMMRMRRM";

            position.StartMoving(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Instruction.ToString()}";
            var expectedOutput = "2 3 S";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestScanrio_33E_MRRRRRRRRRRR()
        {
            Position position = new Position()
            {
                X = 3,
                Y = 3,
                Instruction = Instructions.E
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "MRRRRRRRRRRR";

            position.StartMoving(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Instruction.ToString()}";
            var expectedOutput = "2 3 S";

            Assert.AreNotEqual(expectedOutput, actualOutput);
        }
    }
}