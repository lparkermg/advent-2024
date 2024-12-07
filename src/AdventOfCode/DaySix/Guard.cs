using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DaySix
{
    internal class Guard
    {
        public Vector2 CurrentPosition;
    }

    internal static class Directions
    {
        public readonly static Vector2 North = new Vector2(0.0f, -1.0f);

        public readonly static Vector2 East = new Vector2(1.0f, 0.0f);

        public readonly static Vector2 South = new Vector2(0.0f, 1.0f);

        public readonly static Vector2 West = new Vector2(-1.0f, 0.0f);
    }
}
