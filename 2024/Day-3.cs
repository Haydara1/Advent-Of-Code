// 2024:
// Day 3: Mull it Over:

string input = File.ReadAllText("../../../input");

// Define a function to check if it is a valid multiplication:
int Multiply(string s)
{
    int output = 0;

    if (!s.Contains('(') || !s.Contains(')') || !s.Contains(','))
        return output;

    if (s[0] != '(')
        return output;


    bool parseInteger1 = true;
    // Construct the two numbers
    string number1 = "";
    string number2 = "";

    // Check if we finished with a ).
    bool closed = false;
    
    for (int i = 1; i < 9; i++)
    {   
        if(i >= s.Length) break;
        
        if(char.IsDigit(s[i])) 
        {
            if(parseInteger1)
                number1 += s[i];

            else number2 += s[i];
        }
        // If this case, change the number.
        else if(s[i] == ',') parseInteger1 = false;
        
        else if (s[i] == ')')
        {
            closed = true;
        }
        
        else // Break if the character is anything else
        {
            break;
        }
    }
    
    if(string.IsNullOrEmpty(number1) || string.IsNullOrEmpty(number2)
       || !closed) return output;
    
    output = int.Parse(number1) * int.Parse(number2);

    return output;
}

long output = 0;

for (int i = 0; i < input.Length - 3; i++)
{
    if (input[i] == 'm')
    {
        if (input[i + 1] == 'u' && input[i + 2] == 'l')
        {
            output += Multiply(input.Substring(i + 3)); // Give max length
        }
    }
}

Console.WriteLine(output);

// Answer: 170778545

// Part two:

// This time we should handle do's and don't's. 

output = 0;

bool doFunction = true; // Initialize to true since the first mul is a do.

for (int i = 0; i < input.Length - 3; i++)
{
    if (input[i] == 'm')
    {
        if (input[i + 1] == 'u' && input[i + 2] == 'l')
        {
            output += doFunction ? Multiply(input.Substring(i + 3)) : 0; // Give max length
        }
    }
    
    else if (input[i] == 'd' && input[i + 1] == 'o')
    {
        if(input[i + 2] == '(' && input[i + 3] == ')') doFunction = true;
        
        else if(input.Substring(i, 7) == "don't()")  doFunction = false;
    }
}

Console.WriteLine(output);

// Answer: 82868252
