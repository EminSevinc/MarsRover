using System;

namespace MarsRover.Library.Observer
{
    class MailObserver : IObserver
    {
        public void Notify(int x, int y, string direction, string movementCode = "", bool isLocated = true)
        {
            //Send Email about movement
        }
    }
}
