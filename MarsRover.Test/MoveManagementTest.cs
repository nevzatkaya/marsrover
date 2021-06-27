using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Bussiness;
using MarsRover.Model;
using System.Collections.Generic;

namespace MarsRover.Test
{
    [TestClass]
    public class MoveManagementTest
    {
        Position firstRoversPosition;
        List<Command> listFirstRoversInstruction;
        Position secondRoversPosition;
        List<Command> listSecondRoversInstruction;
        [TestInitialize]
        public void TestInitialize()
        {
            firstRoversPosition = new Position()
            {
                CoordinateX = 1,
                CoordinateY = 2,
                CurrentDirection = Direction.N
            };

            listFirstRoversInstruction = new List<Command>()
            {
             Command.L, Command.M,Command.L, Command.M,Command.L, Command.M,Command.L, Command.M,Command.M
            };

            secondRoversPosition = new Position()
            {
                CoordinateX = 3,
                CoordinateY = 3,
                CurrentDirection = Direction.E
            };

            listSecondRoversInstruction = new List<Command>()
            {
             Command.M, Command.M,Command.R, Command.M, Command.M,Command.R, Command.M,Command.R, Command.R,Command.M,
            };
        }
        [TestMethod]
        public void Move_In_Happy_Path()
        {
            MoveManagement moveManagement = new MoveManagement(5, 5);
            

            moveManagement.move(firstRoversPosition, listFirstRoversInstruction);
            moveManagement.move(secondRoversPosition, listSecondRoversInstruction);

            Assert.AreEqual("13N", String.Format("{0}{1}{2}", firstRoversPosition.CoordinateX, firstRoversPosition.CoordinateY, firstRoversPosition.CurrentDirection.ToString()));
            Assert.AreEqual("51E", String.Format("{0}{1}{2}", secondRoversPosition.CoordinateX, secondRoversPosition.CoordinateY, secondRoversPosition.CurrentDirection.ToString()));
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException), "X coordinate's length is exceeded")]
        public void Move_X_Coordinate_Exceeded_MaxX()
        {
            MoveManagement moveManagement = new MoveManagement(1, 5);            
            moveManagement.move(firstRoversPosition, listFirstRoversInstruction);
            moveManagement.move(secondRoversPosition, listSecondRoversInstruction);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException), "Y coordinate's length is exceeded")]
        public void Move_Y_Coordinate_Exceeded_MaxY()
        {
            MoveManagement moveManagement = new MoveManagement(5, 2);           
            moveManagement.move(firstRoversPosition, listFirstRoversInstruction);
            moveManagement.move(secondRoversPosition, listSecondRoversInstruction);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException), "This direction is invalid")]
        public void Move_Undefined_Direction()
        {
            MoveManagement moveManagement = new MoveManagement(5, 2);
            firstRoversPosition.CurrentDirection = Direction.None;
            moveManagement.move(firstRoversPosition, listFirstRoversInstruction);
            moveManagement.move(secondRoversPosition, listSecondRoversInstruction);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException), "This command is invalid")]
        public void Move_Undefined_Command()
        {
            MoveManagement moveManagement = new MoveManagement(5, 2);
           
            moveManagement.move(firstRoversPosition, new List<Command>() { Command.None });
            moveManagement.move(secondRoversPosition, listSecondRoversInstruction);
        }
    }
}
