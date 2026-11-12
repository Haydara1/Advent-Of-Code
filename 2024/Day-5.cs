// 2024:
// Day 5: Print Queue

// Parse input
string input = File.ReadAllText("../../../input");

string[] inputs = input.Split("\n\n");

string[] rules = inputs[0].Split('\n');
string[] updates = inputs[1].Split('\n');

int[] rules1 = new int[rules.Length];
int[] rules2 = new int[rules.Length];

for (int i = 0; i < rules.Length; i++)
{
    int[] line = rules[i].Split('|').Select(l => int.Parse(l)).ToArray();
    
    rules1[i] = line[0];
    rules2[i] = line[1];
}

int[][] updatesArray = new int[updates.Length][];

for (int i = 0; i < updates.Length; i++)
{
    if (string.IsNullOrEmpty(updates[i])) continue;
    
    updatesArray[i] = updates[i].Split(',').Select(l => int.Parse(l)).ToArray();
}

// Construct an array that stores each number and what it can only have after it:
Dictionary<int, List<int>> rulesDictionary = new Dictionary<int, List<int>>();
for (int i = 0; i < rules1.Length; i++)
{
    if (!rulesDictionary.ContainsKey(rules1[i]))
    {
        rulesDictionary.Add(rules1[i], new List<int>());
    }
    
    rulesDictionary[rules1[i]].Add(rules2[i]);
}

long output = 0;
List<int> incorrectIndices = new List<int>(); // This is used for the second part.

// Check each line:
for (int i = 0; i < updatesArray.Length - 1; i++)
{
    bool correct = true;
    ;
    // For each number in the line except for the last
    for (int j = 0; j < updatesArray[i].Length - 1; j++)
    {
        // If the dictionary doesn't contain this key, it means it should be the last number but it isn't the case.
        if (!rulesDictionary.ContainsKey(updatesArray[i][j]))
        {
            correct = false;
            break;
        }
        
        // Check all the numbers after the specified number.
        for (int k = j + 1; k < updatesArray[i].Length; k++)
        {
            
            if(!rulesDictionary[updatesArray[i][j]].Contains(updatesArray[i][k]))
            {
                correct = false;
                break;
            }
        }

        if (!correct) break;
    }

    if (correct)
        output += updatesArray[i][updatesArray[i].Length / 2];
    else incorrectIndices.Add(i);

}

Console.WriteLine(output);

// Answer: 4872

// First let's get an array of incorrect updates:
int[][] incorrectUpgrades = new int[incorrectIndices.Count][];

// Assign the incorrect upgrades.
for (int i = 0; i < incorrectIndices.Count; i++)
    incorrectUpgrades[i] = updatesArray[incorrectIndices[i]];

// Define a function that corrects the incorrect upgrade
int[] Correct(int[] incorrectUpgrade)
{
    for (int j = 0; j < incorrectUpgrade.Length - 1; j++)
    {
        // If the dictionary doesn't contain this key, it means it should be the last number but it isn't the case.
        if (!rulesDictionary.ContainsKey(incorrectUpgrade[j]))
        {
            // Swap the current with the last number:
            int lastIndex = incorrectUpgrade.Length - 1;
            
            incorrectUpgrade[j] += incorrectUpgrade[lastIndex];
            incorrectUpgrade[lastIndex] = incorrectUpgrade[j] - incorrectUpgrade[lastIndex];
            incorrectUpgrade[j] -= incorrectUpgrade[lastIndex];

            return Correct(incorrectUpgrade);
        }

        // Check all the numbers after the specified number.
        for (int k = j + 1; k < incorrectUpgrade.Length; k++)
        {
            if (!rulesDictionary[incorrectUpgrade[j]].Contains(incorrectUpgrade[k]))
            {
                // Switch between j and k:
                
                incorrectUpgrade[j] += incorrectUpgrade[k];
                incorrectUpgrade[k] = incorrectUpgrade[j] - incorrectUpgrade[k];
                incorrectUpgrade[j] -= incorrectUpgrade[k];

                return Correct(incorrectUpgrade);
            }
        }

    }

    return incorrectUpgrade;
}

output = 0;

for (int i = 0; i < incorrectIndices.Count; i++)
{
    incorrectUpgrades[i] = Correct(incorrectUpgrades[i].Clone() as int[]);
    
    output +=  incorrectUpgrades[i][incorrectUpgrades[i].Length / 2];
}

Console.WriteLine(output);

// Answer: 5564
