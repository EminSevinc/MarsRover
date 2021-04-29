using MarsRover.Library;
using MarsRover.Library.Helper;
using MarsRover.Library.Interface;
using System;
using System.Collections.Generic;
using Validator;

namespace MarsRoverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Inputs:
            //5 5
            //1 2 N
            //LMLMLMLMM
            //Expected Output:
            //1 3 N

            //Test Inputs:
            //3 3 E
            //MMRMMRMRRM
            //Expected Output:
            //5 1 E

            Console.WriteLine("Please enter X and Y coordinates of surface (5 5) :");
            string surfaceCoordinates = Console.ReadLine();
            Validation.ValidateCoordinates(surfaceCoordinates);
            ICoordinate surface = new Surface(surfaceCoordinates);

            Console.WriteLine("\nPlease enter the location (X Y) and direction (N, W, E or S) you want to land the rover (1 2 N) :");
            string roverArguments = Console.ReadLine();
            Validation.ValidateCoordinatesAndDirection(roverArguments);
            IRover rover = new Rover(roverArguments, surface);

            Console.WriteLine("\nSurface was created and rover was landed succesfully\n");

            do
            {
                Console.WriteLine("\nPlease enter the commands (M, L or R) you want to move the rover :");
                string moves = Console.ReadLine();
                List<string> movements = Movement.BuildMovement(moves);

                foreach (var movement in movements)
                {
                    rover.Move(movement);
                }                

            } while (true);
        }
    }
}
