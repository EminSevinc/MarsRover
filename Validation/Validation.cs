using System;
using System.Collections.Generic;

namespace Validator
{
    public static class Validation
    {
        public static void ValidateCoordinatesAndDirection(string coordinatesAndDirection)
        {
            ValidateLength(coordinatesAndDirection, 3);

            ValidateXandY(coordinatesAndDirection);

            string[] arr = coordinatesAndDirection.Split(' ');
            string direction = arr[2];
            List<string> directions = new List<string> { "N", "W", "S", "E" };
            if (!directions.Contains(direction))
                throw new ArgumentException("Input string did not have a correct direction! ('N', 'W', 'S', 'E')");
        }

        public static void ValidateCoordinates(string coordinates)
        {
            ValidateLength(coordinates, 2);

            ValidateXandY(coordinates);
        }

        private static void ValidateLength(string coordinates, int length)
        {
            if (coordinates.Trim().Split(' ').Length != length)
                throw new ArgumentException("Input string was not in a correct length!");
        }

        private static void ValidateXandY(string coordinates)
        {
            string[] arr = coordinates.Split(' ');
            try
            {
                int x = Convert.ToInt32(arr[0]);
                int y = Convert.ToInt32(arr[1]);
            }
            catch (Exception)
            {
                throw new ArgumentException("You have to write integer coordinate values! (Example 1 1)");
            }
        }
    }
}
