using MarsRover.Library.Interface;
using System;
using System.Collections.Generic;
using MarsRover.Library.Observer;

namespace MarsRover.Library
{
    public class Rover : IRover
    {
        public string Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ICoordinate Surface { get; set; }
        public Rover(string CoordinatesAndDirection, ICoordinate surface)
        {
            string[] arr = CoordinatesAndDirection.Split(' ');

            this.X = Convert.ToInt32(arr[0]);
            this.Y = Convert.ToInt32(arr[1]);
            this.Direction = arr[2];
            this.Surface = surface;

            this.Attach(new CustomerObserver());
            this.Attach(new MailObserver());
        }

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void Notify(string movementCode = "", bool isLocated = true)
        {
            _observers.ForEach(o => { o.Notify(this.X, this.Y, this.Direction, movementCode, isLocated); });
        }

        public void Move(string movementCode)
        {
            switch (movementCode.ToUpper())
            {
                case "M":
                    MoveStraight();
                    break;
                case "L":
                    TurnLeft();
                    break;
                case "R":
                    TurnRight();
                    break;
                default:
                    this.Notify(movementCode, false); 
                    break;
            }
        }

        private void MoveStraight()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Y += 1;
                    break;

                case Directions.East:
                    this.X += 1;
                    break;

                case Directions.South:
                    this.Y -= 1;
                    break;

                case Directions.West:
                    this.X -= 1;
                    break;
            }

            checkLastPosition();

            this.Notify();
        }

        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.East;
                    break;

                case Directions.East:
                    this.Direction = Directions.South;
                    break;

                case Directions.South:
                    this.Direction = Directions.West;
                    break;

                case Directions.West:
                    this.Direction = Directions.North;
                    break;
            }

            this.Notify();
        }

        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.West;
                    break;

                case Directions.West:
                    this.Direction = Directions.South;
                    break;

                case Directions.South:
                    this.Direction = Directions.East;
                    break;

                case Directions.East:
                    this.Direction = Directions.North;
                    break;
            }

            this.Notify();
        }

        private void checkLastPosition()
        {
            if (X < 0 || X > Surface.X)
            {
                throw new ArgumentException("The rover has gone out of range");
            }
            else if (Y < 0 || Y > Surface.Y)
            {
                throw new ArgumentException("The rover has gone out of range");
            }
        }
    }
}
