using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Bussiness
{
    public class MoveManagement
    {
        private readonly int maxX;
        private readonly int maxY;
        
        public MoveManagement(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }
        public void move(Position position,List<Command> listMoveCommand)
        {
            foreach (var item in listMoveCommand)
            {
                switch (item)
                {
                    case Command.L:
                        turnLeft(position);
                        break;
                    case Command.R:
                        turnRight(position);
                        break;
                    case Command.M:
                        moveForward(position);
                        break;
                    default:
                        throw new InvalidOperationException("This command is invalid");
                }
            }
        }
        private void turnLeft(Position position)
        {
            switch (position.CurrentDirection)
            {
                case Direction.N:
                    position.CurrentDirection = Direction.W;
                    break;
                case Direction.S:
                    position.CurrentDirection = Direction.E;
                    break;
                case Direction.W:
                    position.CurrentDirection = Direction.S;
                    break;
                case Direction.E:
                    position.CurrentDirection = Direction.N;
                    break;
                default:
                    throw new InvalidOperationException("This direction is invalid");
            }
        }

        private void turnRight(Position location)
        {
            switch (location.CurrentDirection)
            {
                case Direction.N:
                    location.CurrentDirection = Direction.E;
                    break;
                case Direction.S:
                    location.CurrentDirection = Direction.W;
                    break;
                case Direction.W:
                    location.CurrentDirection = Direction.N;
                    break;
                case Direction.E:
                    location.CurrentDirection = Direction.S;
                    break;
                default:
                    throw new InvalidOperationException("This direction is invalid");
            }
        }

        private void moveForward(Position position)
        {
            switch (position.CurrentDirection)
            {
                case Direction.N:
                    SetCoordinateY(position, 1);
                    break;
                case Direction.S:
                    SetCoordinateY(position, -1);
                    break;
                case Direction.W:
                    SetCoordinateX(position, -1);
                    break;
                case Direction.E:
                    SetCoordinateX(position, 1);
                    break;
                default:
                    throw new InvalidOperationException("This direction is invalid");
            }
        }

        private void SetCoordinateY(Position position, int unit)
        {           
            position.CoordinateY += unit;
            if (position.CoordinateY > maxY)
            {
                throw new InvalidOperationException("Y coordinate's length is exceeded");
            }
        }


        private void SetCoordinateX(Position position, int unit)
        {            
            position.CoordinateX += unit;
            if (position.CoordinateX > maxX)
            {
                throw new InvalidOperationException("X coordinate's length is exceeded");
            }
        }

    }
}
