using System;

namespace MarsRover.Library.Observer
{
    class CustomerObserver : IObserver
    {
        public void Notify(int x, int y, string direction, string movementCode = "", bool isLocated = true)
        {
            if (isLocated)
                Console.WriteLine($"Rover X Coordinate : {x} , Y Coordinate : {y} , Direction : {direction}");
            else
                Console.WriteLine($"The rover could not be moved due to an invalid movement character : {movementCode}");
        }
    }
}
