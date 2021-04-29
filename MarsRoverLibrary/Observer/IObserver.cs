namespace MarsRover.Library.Observer
{
    public interface IObserver
    {
        void Notify(int x, int y, string direction, string movementCode = "", bool isLocated = true);
    }
}
