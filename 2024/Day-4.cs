// 2024:
// Day 4: Ceres Search:

string[] lines = File.ReadAllLines("../../../input");
char[][] grid = new char[lines.Length][];

for (int i = 0; i < lines.Length; i++)
    grid[i] = lines[i].ToCharArray();

int output = 0;

for (int i = 0; i < grid.Length; i++)
{
    for (int j = 0; j < grid[i].Length; j++)
    {
        if (grid[i][j] == 'X')
        {
            // Check all directions.
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0) continue;
                    
                    if(i + 3 * x < 0 || i + 3 * x >= grid.Length
                       || j + 3 * y < 0 || j + 3 * y >= grid[i].Length) continue;
                    
                    
                    if(grid[i + x][j + y] == 'M' &&
                       grid[i + 2 * x][j + 2 * y] == 'A' &&
                       grid[i + 3 * x][j + 3 * y] == 'S') output++;
                }
            }
        }
    }
}

Console.WriteLine(output);

// Answer: 2447

output = 0;

int[] topLeftDirection = [-1, -1];
int[] topRightDirection = [-1, 1];
int[] bottomLeftDirection = [1, -1];
int[] bottomRightDirection = [1, 1];

// Part two: 
for (int i = 1; i < grid.Length - 1; i++)
{
    for (int j = 1; j < grid[i].Length - 1; j++)
    {
        if (grid[i][j] == 'A')
        {
            char topLeft, topRight, bottomLeft, bottomRight;
            
            topLeft = grid[i + topLeftDirection[0]]
                [j +  topLeftDirection[1]];
            
            topRight = grid[i + topRightDirection[0]]
                [j +  topRightDirection[1]];
            
            bottomLeft = grid[i + bottomLeftDirection[0]]
                [j + bottomLeftDirection[1]];
            
            bottomRight = grid[i + bottomRightDirection[0]]
                [j + bottomRightDirection[1]];
            
            if ((topLeft == 'M' && bottomRight == 'S' ||
                 topLeft == 'S' && bottomRight == 'M') &&
                (topRight == 'M' && bottomLeft == 'S' ||
                 topRight == 'S' && bottomLeft == 'M'))
            {
                output++;
            }    
        }
    }
}

Console.WriteLine(output);

// Answer: 1868
