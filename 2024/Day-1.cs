// 2024:
// Day 1: Historian Hysteria

string[] lines = File.ReadAllLines("../../../input")
    .Where(l => !string.IsNullOrWhiteSpace(l))
    .ToArray();


int[] array1 = new int[lines.Length];
int[] array2 = new int[lines.Length];

for (int i = 0; i < lines.Length; i++)
{
    string[] parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

    array1[i] = int.Parse(parts[0]);
    array2[i] = int.Parse(parts[1]);
}

Array.Sort(array1);
Array.Sort(array2);

int output = 0;

for (int i = 0; i < array1.Length; i++)
{
    output += Math.Abs(array1[i] - array2[i]);
}

Console.WriteLine(output);

// Answer: 1222801

// Part two:
// We don't care about the order, so we can keep the array sorted.

int similarity = 0;

for (int i = 0; i < array1.Length; i++)
{
    if (!array2.Contains(array1[i])) continue;

    similarity += array1[i] * array2.Count(l => l == array1[i]);
}

Console.WriteLine(similarity);

// Answer: 22545250
