using MarsRover.Library.Interface;
using System;

namespace MarsRover.Library
{
    public class Surface : ICoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Surface(string Coordinates)
        {
            string[] coordinates = Coordinates.Split(' ');
            this.X = Convert.ToInt32(coordinates[0]);
            this.Y = Convert.ToInt32(coordinates[1]);
        }
    }
}
