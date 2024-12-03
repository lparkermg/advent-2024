using System.Text.RegularExpressions;

namespace DayThree
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            //var exampleData = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

            var data = await File.ReadAllTextAsync("./data.txt");

            var matches = Regex.Matches(data, "mul[(][0-9]{1,3},[0-9]{1,3}[)]").ToList();

            var result = 0;

            foreach(var match in matches)
            {
                var trimmed = match.Value.Replace("mul(", string.Empty).Replace(")", string.Empty);
                var split = trimmed.Split(',');
                result += int.Parse(split[0]) * int.Parse(split[1]);
            }
            Console.WriteLine($"The result is {result}!");
        }
    }
}
