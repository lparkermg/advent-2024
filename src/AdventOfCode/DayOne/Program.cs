namespace DayOne
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var loadedData = await File.ReadAllLinesAsync("./data.txt");

            // Populate the lists
            var leftList = new List<int>();
            var rightList = new List<int>();

            foreach (var line in loadedData)
            {
                leftList.Add(int.Parse(line.Split("   ")[0]));
                rightList.Add(int.Parse(line.Split("   ")[1]));
            }

            // Order the lists so they're assending.
            leftList = leftList.OrderBy(i => i).ToList();
            rightList = rightList.OrderBy(i => i).ToList();


            var distances = new List<int>();
            for(var i = 0; i < leftList.Count; i++)
            {
                var leftItem = leftList[i];
                var rightItem = rightList[i];
                var distance = 0;

                if(leftItem > rightItem)
                {
                    distance = leftItem - rightItem;
                }
                else if(leftItem < rightItem)
                {
                    distance = rightItem - leftItem;
                }

                distances.Add(distance);
            }

            Console.WriteLine($"Total Distance for both lists is {distances.Sum()}");
        }
    }
}
