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
            Direction = Directions.North;
        }

        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.West;
                    break;

                case Directions.South:
                    this.Direction = Directions.East;
                    break;

                case Directions.East:
                    this.Direction = Directions.North;
                    break;

                case Directions.West:
                    this.Direction = Directions.South;
                    break;

                default:
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.East;
                    break;

                case Directions.South:
                    this.Direction = Directions.West;
                    break;

                case Directions.East:
                    this.Direction = Directions.South;
                    break;

                case Directions.West:
                    this.Direction = Directions.North;
                    break;

                default:
                    break;
            }
        }

        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.LocationY += 1;
                    break;

                case Directions.South:
                    this.LocationY -= 1;
                    break;

                case Directions.East:
                    this.LocationX += 1;
                    break;

                case Directions.West:
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

                if (this.LocationX < 0 || this.LocationX > maxPoints[0] || this.LocationY < 0 || this.LocationY > maxPoints[1])
                {
                    throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }
    }

    public enum Directions
    {
        North = 1,
        South = 2,
        East = 3,
        West = 4
    }
}