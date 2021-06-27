using MarsRover.Bussiness;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string coordinateXyLengthString= Console.ReadLine();
            string firstRoversPositionString = Console.ReadLine();
            string firstRoversInstructionString = Console.ReadLine();
            string secondRoversPositionString = Console.ReadLine();
            string secondRoversInstructionString = Console.ReadLine();

            int maxX =Convert.ToInt32(coordinateXyLengthString[0].ToString());
            int maxY = Convert.ToInt32(coordinateXyLengthString[0].ToString());

            Position firstRoversPosition = new Position()
            {
                CoordinateX = Convert.ToInt32(firstRoversPositionString[0].ToString()),
                CoordinateY = Convert.ToInt32(firstRoversPositionString[1].ToString()),
                CurrentDirection = (Direction)Enum.Parse(typeof(Direction), firstRoversPositionString[2].ToString())
            };
            List<Command> listFirstRoversInstruction = new List<Command>();
            foreach (var item in firstRoversInstructionString)
            {
                listFirstRoversInstruction.Add((Command)Enum.Parse(typeof(Command), item.ToString()));
            }

            Position secondRoversPosition = new Position()
            {
                CoordinateX = Convert.ToInt32(secondRoversPositionString[0].ToString()),
                CoordinateY = Convert.ToInt32(secondRoversPositionString[1].ToString()),
                CurrentDirection = (Direction)Enum.Parse(typeof(Direction), secondRoversPositionString[2].ToString())
            };
            List<Command> listSecondFirstRoversInstruction = new List<Command>();
            foreach (var item in secondRoversInstructionString)
            {
                listSecondFirstRoversInstruction.Add((Command)Enum.Parse(typeof(Command), item.ToString()));
            }

            MoveManagement management = new MoveManagement(maxX,maxY);
            management.move(firstRoversPosition, listFirstRoversInstruction);
            management.move(secondRoversPosition, listSecondFirstRoversInstruction);          

            Console.WriteLine(String.Format("{0}{1}{2}", firstRoversPosition.CoordinateX , firstRoversPosition.CoordinateY , firstRoversPosition.CurrentDirection));
            Console.WriteLine(String.Format("{0}{1}{2}", secondRoversPosition.CoordinateX, secondRoversPosition.CoordinateY, secondRoversPosition.CurrentDirection));
            Console.ReadLine();
        }
    }
}
