// 2024:
// Day 2: Red-Nosed Reports:

string[] input = File.ReadAllLines("../../../input")
    .Where(l => !String.IsNullOrWhiteSpace(l))
    .ToArray();
    
// Define a function to check whether an integer array is safe or not:
bool IsSafe(int[] report)
{
    bool increasing = report[1] > report[0];

    for (int i = 0; i < report.Length - 1; i++)
    {
        int diff = report[i + 1] - report[i];

        // Direction must stay consistent
        if (increasing && diff <= 0) return false;
        if (!increasing && diff >= 0) return false;

        // Step must be 1..3
        if (Math.Abs(diff) > 3) return false;
    }

    return true;
}

int safeReports = 0;

foreach (string line in input)
{
    int[] report = line.Split(' ').Select(x => int.Parse(x)).ToArray();
    
    safeReports += IsSafe(report) ? 1 : 0;
}

Console.WriteLine(safeReports);

// Answer: 483
// Part two:

// Redefine the function
bool IsSafeDampened(int[] report)
{
    if (IsSafe(report)) return true;
    
    // Try removing one index at a time until it works:
    for (int i = 0; i < report.Length; i++)
    {
        int[] dampenedReport = new int[report.Length - 1];

        for (int j = 0; j < report.Length - 1; j++)
        {
            if(j >= i) dampenedReport[j] = report[j + 1];
            else dampenedReport[j] = report[j];
        }

        if (IsSafe(dampenedReport)) return true;
    }
    
    return false;
}

safeReports = 0;

foreach (string line in input)
{
    int[] report = line.Split(' ').Select(x => int.Parse(x)).ToArray();
    
    safeReports += IsSafeDampened(report) ? 1 : 0;
}

Console.WriteLine(safeReports);

// Answer: 528
