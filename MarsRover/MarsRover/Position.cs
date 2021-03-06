using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public enum Instructions
    {
        N = 1,//North
        S = 2,//South
        E = 3,//East
        W = 4//West
    }

    public interface IPosition
    {
        void StartMoving(List<int> maxPoints, string moves);
    }

    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Instructions Instruction { get; set; }

        public Position()
        {
            X = Y = 0;
            Instruction = Instructions.N;
        }

        private void Rotate90Left()
        {
            switch (this.Instruction)
            {
                case Instructions.N:
                    this.Instruction = Instructions.W;
                    break;
                case Instructions.S:
                    this.Instruction = Instructions.E;
                    break;
                case Instructions.E:
                    this.Instruction = Instructions.N;
                    break;
                case Instructions.W:
                    this.Instruction = Instructions.S;
                    break;
                default:
                    break;
            }
        }

        private void Rotate90Right()
        {
            switch (this.Instruction)
            {
                case Instructions.N:
                    this.Instruction = Instructions.E;
                    break;
                case Instructions.S:
                    this.Instruction = Instructions.W;
                    break;
                case Instructions.E:
                    this.Instruction = Instructions.S;
                    break;
                case Instructions.W:
                    this.Instruction = Instructions.N;
                    break;
                default:
                    break;
            }
        }

        private void MoveInSameInstruction()
        {
            switch (this.Instruction)
            {
                case Instructions.N:
                    this.Y += 1;
                    break;
                case Instructions.S:
                    this.Y -= 1;
                    break;
                case Instructions.E:
                    this.X += 1;
                    break;
                case Instructions.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        public void StartMoving(List<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        this.MoveInSameInstruction();
                        break;
                    case 'L':
                        this.Rotate90Left();
                        break;
                    case 'R':
                        this.Rotate90Right();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }

                if (this.X < 0 || this.X > maxPoints[0] || this.Y < 0 || this.Y > maxPoints[1])
                {
                    throw new Exception($"Wrong Position (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }
    }
}
