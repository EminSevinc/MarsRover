using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Library.Helper
{
    public static class Movement
    {
        public static List<string> BuildMovement(string Movements)
        {
            Movements = Movements.Replace(" ", "");
            return Movements.ToCharArray().Select(i => i.ToString()).ToList();
        }
    }
}
