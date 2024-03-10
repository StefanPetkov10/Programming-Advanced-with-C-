int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int  cols = dimensions[1];

int playerRow = 0;
int playerCol = 0;
char[,] cupboard = new char[rows, cols];

int players = 0;
int touchedPlayers = 0;
int moves = 0;

for (int row = 0; row < rows; row++)
{
    char[] currentRow = Console.ReadLine()
        .Split(' ',StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        cupboard[row, col] = currentRow[col];

        if (currentRow[col] == 'B')
        {
            playerRow = row;
            playerCol = col;
            cupboard[playerRow, playerCol] = '-';
        }
        if (currentRow[col] == 'P')
        {
            players++;
        }
    }
}

string command;
while ((command = Console.ReadLine()) != "Finish")
{
    if (command == "left")
    {
        if (playerCol == 0 || cupboard[playerRow, playerCol - 1] == 'O')
        {
            continue;
        }

        if (cupboard[playerRow, playerCol - 1] == 'P')
        {
            touchedPlayers++;
            cupboard[playerRow, playerCol - 1] = '-';
        }

        moves++;
        playerCol--;
    }
    else if (command == "right")
    {
        if (playerCol == cols - 1 || cupboard[playerRow, playerCol + 1] == 'O')
        {
            continue;
        }

        if (cupboard[playerRow, playerCol + 1] == 'P')
        {
            touchedPlayers++;
            cupboard[playerRow, playerCol + 1] = '-';
        }

        moves++;
        playerCol++;
    }
    else if (command == "up")
    {
        if (playerRow == 0 || cupboard[playerRow - 1, playerCol] == 'O')
        {
            continue;
        }

        if (cupboard[playerRow - 1, playerCol] == 'P')
        {
            touchedPlayers++;
            cupboard[playerRow - 1, playerCol] = '-';
        }

        moves++;
        playerRow--;
    }
    else if (command == "down")
    {
        if (playerRow == rows - 1 || cupboard[playerRow + 1, playerCol] == 'O')
        {
            continue;
        }

        if (cupboard[playerRow + 1, playerCol] == 'P')
        {
            touchedPlayers++;
            cupboard[playerRow + 1, playerCol] = '-';
        }

        moves++;
        playerRow++;
    }

    if (touchedPlayers == players)
    {
        break;
    }
}
Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedPlayers} Moves made: {moves}");
