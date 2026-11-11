// 2025:
// Day 1: Secret entrance:

// Define a function to return the current number after a combination:
int Combination(int current, string combination)
{
    int amount = int.Parse(combination.Substring(1));
    int delta = combination[0] == 'R' ? amount : -amount;

    // Double-mod keeps the result non-negative for left turns
    return ((current + delta) % 100 + 100) % 100;
}

string input = File.ReadAllText("../../../input");
string[] arrayInput = input.Split('\n');

int output = 0;
int current = 50;

foreach (string line in arrayInput)
{
    if (line == "") continue; // Be careful of the last line of the file.
    
    current = Combination(current, line);
    
    if (current == 0) output++;
}

Console.WriteLine(output);

// Answer: 1092

// Part 2: 

// Update the used function:
(int, int) PassedZeroCombination(int currentDial, string combination)
{
    int amount = int.Parse(combination.Substring(1));
    bool right = combination[0] == 'R';

    // Mirror left turns so both directions use the same "moving right" math
    int start = right ? currentDial : (100 - currentDial) % 100;
    int zeros = (start + amount) / 100;

    int delta = right ? amount : -amount;
    int newDial = ((currentDial + delta) % 100 + 100) % 100;

    return (newDial, zeros);
}

current = 50;
int password = 0;

foreach (string line in arrayInput)
{
    if (line == "") continue; // Be careful of the last line of the file.

    int passedZeros = 0;
    
    (current, passedZeros) = PassedZeroCombination(current, line);
    
    password += passedZeros;
}

Console.WriteLine(password);

// Answer: 6616
