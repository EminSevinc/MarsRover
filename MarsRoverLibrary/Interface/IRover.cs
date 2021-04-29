namespace MarsRover.Library.Interface
{
    public interface IRover : ICoordinate
    {
        string Direction { get; set; }
        ICoordinate Surface { get; set; }
        void Move(string MovementCode);
    }
}
