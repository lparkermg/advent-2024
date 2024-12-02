namespace DayTwo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var loadedReports = await File.ReadAllLinesAsync("./data.txt");
            var reports = new List<Report>();

            foreach(var report in loadedReports)
            {
                var levels = report.Split(" ").Select(i => int.Parse(i)).ToList();
                reports.Add(new Report { Levels = levels });
            }

            var safeReports = 0;

            foreach (var report in reports)
            {
                if (IsReportSafe(report))
                {
                    safeReports++;
                }
            }
            Console.WriteLine($"There are {safeReports} safe reports.");
        }

        private static bool IsReportSafe(Report report, bool sub = false)
        {
            int[] reportLevels;

            // Remove a single failure to make report valid. 

            if (report.Levels.First() > report.Levels.Last())
            {
                // First is greater than last so we're decsending
                reportLevels = report.Levels.Reverse().ToArray();

            }
            else
            {
                reportLevels = report.Levels.ToArray();
                // Last is greater than first so we're accending
                
            }
            var isSafe = true;
            for (var i = 0; i < reportLevels.Length - 1; i++)
            {
                var reportItem = reportLevels[i];
                var nextItem = reportLevels[i + 1];
                
                if(nextItem - reportItem > 3 || nextItem - reportItem < 1)
                {
                    isSafe = false;
                }
            }

            if (!isSafe && !sub)
            {
                for(var i = 0; i < reportLevels.Length; i++)
                {
                    var levels = reportLevels.ToList();
                    levels.RemoveAt(i);
                    if (IsReportSafe(new Report { Levels = levels }, true))
                    {
                        return true;
                    }
                }

                return false;
            }

            return isSafe;
        }
    }
}
