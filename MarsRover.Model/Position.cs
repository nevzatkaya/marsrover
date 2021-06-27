﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Model
{
    public class Position
    {
        public Direction CurrentDirection { get; set; }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }
    }
}
