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
                var levels = report.Split(" ").Select(i => int.Parse(i)).ToArray();
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

        private static bool IsReportSafe(Report report)
        {
            int[] reportLevels;
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

            for (var i = 0; i < reportLevels.Count() - 1; i++)
            {
                var reportItem = reportLevels[i];
                var nextItem = reportLevels[i + 1];

                if(reportItem - nextItem > 3 || reportItem - nextItem < 1)
                {
                    return false;
                }
                
            }


            return true;
        }
    }
}
