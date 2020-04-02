using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Position : IPosition
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public Directions Direction { get; set; }

        public Position()
        {
            LocationX = 0;
            LocationY = 0;
            Direction = Directions.N;
        }

        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;

                case Directions.S:
                    this.Direction = Directions.E;
                    break;

                case Directions.E:
                    this.Direction = Directions.N;
                    break;

                case Directions.W:
                    this.Direction = Directions.S;
                    break;

                default:
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;

                case Directions.S:
                    this.Direction = Directions.W;
                    break;

                case Directions.E:
                    this.Direction = Directions.S;
                    break;

                case Directions.W:
                    this.Direction = Directions.N;
                    break;

                default:
                    break;
            }
        }

        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.LocationY += 1;
                    break;

                case Directions.S:
                    this.LocationY -= 1;
                    break;

                case Directions.E:
                    this.LocationX += 1;
                    break;

                case Directions.W:
                    this.LocationX -= 1;
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
                        this.MoveInSameDirection();
                        break;

                    case 'L':
                        this.TurnLeft();
                        break;

                    case 'R':
                        this.TurnRight();
                        break;

                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }
            }
        }
    }

    public enum Directions
    {
        N = 1,
        S = 2,
        E = 3,
        W = 4
    }
}