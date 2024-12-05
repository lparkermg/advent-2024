namespace DayFive
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var orderingRulesData = await File.ReadAllLinesAsync("./ordering-rules.txt");
            var pagesData = await File.ReadAllLinesAsync("./pages.txt");

            // Build rules list
            var rules = orderingRulesData.Select(r => new Rule(r)).ToList();

            var runningTotal = 0;
            var incorrectPages = new List<string>();
            foreach (var page in pagesData) 
            {
                if(TryValidPageOrder(page, rules, out int middlePage))
                {
                    runningTotal += middlePage;
                }
                else
                {
                    incorrectPages.Add(page);
                }
            }

            var incorrectRunningTotal = 0;
            foreach (var page in incorrectPages)
            {
                incorrectRunningTotal += CorrectPageOrder(page, rules);
            }
            // X|Y if both, X, must be printed before Y
            Console.WriteLine($"The total from the middle pages is {runningTotal}...");
            Console.WriteLine($"The total from the incorrect chages is {incorrectRunningTotal}...");
        }

        static bool TryValidPageOrder(string page, IList<Rule> rules, out int middlePage)
        {
            middlePage = 0;

            var parsedPage = page.Split(",").Select(p => int.Parse(p)).ToList();

            foreach(var rule in rules)
            {
                // Contains both X and Y?
                if (!parsedPage.Contains(rule.FirstNumber) || !parsedPage.Contains(rule.SecondNumber))
                {
                    continue;
                }

                // Get index of both and compare their positions.
                var firstPost = parsedPage.IndexOf(rule.FirstNumber);
                var secondPost = parsedPage.IndexOf(rule.SecondNumber);

                if (firstPost >= secondPost)
                {
                    // Ordering is not valid
                    return false;
                }
            }

            middlePage = parsedPage[(int)parsedPage.Count / 2];
            return true;
        }

        static int CorrectPageOrder(string page, IList<Rule> rules)
        {
            var parsedPage = page.Split(",").Select(p => int.Parse(p)).ToList();

            var filteredRules = rules.Where(r => parsedPage.Contains(r.FirstNumber) && parsedPage.Contains(r.SecondNumber)).GroupBy(r => r.FirstNumber).ToDictionary(r => r.Key, i => i.Select(y => y.SecondNumber).ToList());
            

            parsedPage.Sort((a, b) => filteredRules.TryGetValue(a, out var ato) && ato.Contains(b) ? -1 : 1);
            TryValidPageOrder(string.Join(',', parsedPage), rules, out var midPage);
            return midPage;
        }
    }
}
