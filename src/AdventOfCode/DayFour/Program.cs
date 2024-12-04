namespace DayFour
{
    internal class Program
    {
        private static readonly char[] _validChars = ['X', 'M', 'A', 'S'];
        static async Task Main(string[] args)
        {
            var lines = await File.ReadAllLinesAsync("./data.txt");
            var xMax = lines[0].Length;
            var yMax = lines.Length;
            char?[,] matrix = new char?[xMax,yMax];

            for(var x = 0; x < xMax; x++)
            {
                for(var y = 0; y < yMax; y++)
                {
                    if (_validChars.Any(c => c == lines[y][x]))
                    {
                        matrix[x,y] = lines[y][x];
                    }
                }
            }

            for(var x = 0; x < xMax; x++)
            {
                for(var y = 0; y < yMax; y++)
                {
                    // WOrk out if we should even do a check here.
                    // For valid chars check the potential positions for rest of word (for example if A is the char we're on and we want to check for horizontal we would check -2, -1 and 1)
                    // If we have a match that isn't a duplicate, we add coords to list
                    // Otherwise we do nothing.
                    // Move of to next
                }
            }

            // Count the amount of items we have and return the count.
            Console.WriteLine("Hello, World!");
        }
    }
}
