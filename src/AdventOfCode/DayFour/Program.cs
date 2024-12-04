﻿namespace DayFour
{
    internal class Program
    {
        private static readonly char[] _validChars = ['X', 'M', 'A', 'S'];
        static async Task Main(string[] args)
        {
            var lines = await File.ReadAllLinesAsync("./data.txt");
            var xMax = lines[0].Length;
            var yMax = lines.Length;
            var validCells = new List<Cell>();

            for(var x = 0; x < xMax; x++)
            {
                for(var y = 0; y < yMax; y++)
                {
                    if (_validChars.Any(c => c == lines[y][x]))
                    {
                        validCells.Add(new Cell
                        {
                            X = x,
                            Y = y,
                            Character = lines[y][x]
                        });
                    }
                }
            }

            var startCells = validCells.Where(c => c.Character == _validChars[0]).ToList();
            var endCells = validCells.Where(c => c.Character == _validChars[3]).ToList();

            var count = 0;
            foreach (var cell in startCells)
            {
                count += CountFullWords(cell, validCells);
            }

            // Count the amount of items we have and return the count.
            Console.WriteLine($"There are {count} XMAS's");
        }

        private static int CountFullWords(Cell startCell, IList<Cell> fullGrid)
        {
            var count = 0;
            // N (0, 1, 2, 3) + on y axis
            count += fullGrid.Where(c => c.X == startCell.X && ((c.Y == startCell.Y + 1 && c.Character == 'M') || (c.Y == startCell.Y + 2 && c.Character == 'A') || (c.Y == startCell.Y + 3 && c.Character == 'S'))).Count() == 3 ? 1 : 0;
            // NE (0, 1, 2, 3) + on both axis
            count += fullGrid.Where(c => (c.X == startCell.X + 1 && c.Y == startCell.Y + 1 && c.Character == 'M') || (c.X == startCell.X + 2 && c.Y == startCell.Y + 2 && c.Character == 'A') || (c.X == startCell.X + 3 && c.Y == startCell.Y + 3 && c.Character == 'S')).Count() == 3 ? 1 : 0;
            // E (0, 1, 2, 3) + on x axis
            count += fullGrid.Where(c => c.Y == startCell.Y && ((c.X == startCell.X + 1 && c.Character == 'M') || (c.X == startCell.X + 2 && c.Character == 'A') || (c.X == startCell.X + 3 && c.Character == 'S'))).Count() == 3 ? 1 : 0;
            // SE (0, 1, 2, 3) + on x axis, - on y axis
            count += fullGrid.Where(c => (c.X == startCell.X + 1 && c.Y == startCell.Y - 1 && c.Character == 'M') || (c.X == startCell.X + 2 && c.Y == startCell.Y - 2 && c.Character == 'A') || (c.X == startCell.X + 3 && c.Y == startCell.Y - 3 && c.Character == 'S')).Count() == 3 ? 1 : 0;
            // S (0, 1, 2, 3) - on y axis
            count += fullGrid.Where(c => c.X == startCell.X && ((c.Y == startCell.Y - 1 && c.Character == 'M') || (c.Y == startCell.Y - 2 && c.Character == 'A') || (c.Y == startCell.Y - 3 && c.Character == 'S'))).Count() == 3 ? 1 : 0;
            // SW (0, 1, 2, 3) - on both axis
            count += fullGrid.Where(c => (c.X == startCell.X - 1 && c.Y == startCell.Y - 1 && c.Character == 'M') || (c.X == startCell.X - 2 && c.Y == startCell.Y - 2 && c.Character == 'A') || (c.X == startCell.X - 3 && c.Y == startCell.Y - 3 && c.Character == 'S')).Count() == 3 ? 1 : 0;
            // W (0, 1, 2, 3) - on x axis
            count += fullGrid.Where(c => c.Y == startCell.Y && ((c.X == startCell.X - 1 && c.Character == 'M') || (c.X == startCell.X - 2 && c.Character == 'A') || (c.X == startCell.X - 3 && c.Character == 'S'))).Count() == 3 ? 1 : 0;
            // NW (0, 1, 2, 3) + on y axis, - on x axis
            count += fullGrid.Where(c => (c.X == startCell.X - 1 && c.Y == startCell.Y + 1 && c.Character == 'M') || (c.X == startCell.X - 2 && c.Y == startCell.Y + 2 && c.Character == 'A') || (c.X == startCell.X - 3 && c.Y == startCell.Y + 3 && c.Character == 'S')).Count() == 3 ? 1 : 0;

            return count;
        }
    }
}
