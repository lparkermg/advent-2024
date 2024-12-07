using System.Numerics;

namespace DaySix
{
    internal class Program
    {
        private readonly static char _start = '^';
        private readonly static char _obstructions = '#';

        private static Vector2 _currentDirection = Directions.North;

        static void Main(string[] args)
        {
            var mapData = File.ReadAllLines("./map.txt");

            var map = new Map();

            for (var y = 0; y < mapData.Length; y++)
            {
                for (var x = 0; x < mapData[y].Length; x++)
                {
                    var hasObstruction = false;
                    if (mapData[y][x] == _start)
                    {
                        map.StartPosition = new Vector2(x, y);
                    }
                    else if (mapData[y][x] == _obstructions)
                    {
                        hasObstruction = true;
                    }

                    map.MapGrid.Add(new Cell(hasObstruction, x, y));
                }
            }

            var hasCompleted = false;
            var currentPosition = map.StartPosition;
            var visitedPositions = new List<Cell>();
            while (!hasCompleted)
            {
                var nextPos = currentPosition + _currentDirection;

                var cell = map.MapGrid.FirstOrDefault(c => c.X == nextPos.X && c.Y == nextPos.Y);

                if (cell == null)
                {
                    //Guard has exited the map.
                    break;
                }

                if (cell.HasObject)
                {
                    Turn();
                }
                else
                {
                    currentPosition = nextPos;
                    visitedPositions.Add(cell);
                }
            }
            var distintPositionsVisited = visitedPositions.DistinctBy(c => c.CellId).Count();
            Console.WriteLine($"The guard visited {distintPositionsVisited} positions.");
        }

        private static void Turn()
        {
            if (_currentDirection == Directions.North)
            {
                _currentDirection = Directions.East;
            }
            else if (_currentDirection == Directions.East)
            {
                _currentDirection = Directions.South;
            }
            else if (_currentDirection == Directions.South)
            {
                _currentDirection = Directions.West;
            }
            else if (_currentDirection == Directions.West)
            {
                _currentDirection = Directions.North;
            }
        }
    }
}
