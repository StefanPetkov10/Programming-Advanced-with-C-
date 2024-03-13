
int size = int.Parse(Console.ReadLine());

string[] comands = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);


char[,] field = new char[size, size];

int squirrelRow = -1;
int squirrelCol = -1;

int hazelnutCount = 3;

bool outOfBounds = false;

for (int row = 0; row < size; row++)
{
    string currentRow = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        field[row, col] = currentRow[col];

        if (field[row, col] == 's')
        {
            squirrelRow = row;
            squirrelCol = col;

            field[squirrelRow, squirrelCol] = '*';
        }
    }
}

int hazelnutToCollect = 0;

for (int i = 0; i < comands.Length; i++)
{
    if (comands[i] == "left")
    {
        if (squirrelCol == 0)
        {
            outOfBounds = true;
            Console.WriteLine("The squirrel is out of the field.");
            break;
        }
        else
        {
            squirrelCol--;
            if (field[squirrelRow, squirrelCol] == 'h')
            {
                field[squirrelRow, squirrelCol] = '*';
                hazelnutToCollect++;
            }
        }
    }
    else if (comands[i] == "right")
    {
        if (squirrelCol == size - 1) 
        {
            outOfBounds = true;
            Console.WriteLine("The squirrel is out of the field.");
            break;
        }
        else
        {
            squirrelCol++;
            if (field[squirrelRow, squirrelCol] == 'h')
            {
                field[squirrelRow, squirrelCol] = '*';
                hazelnutToCollect++;
            }
        }
    }
    else if (comands[i] == "down")
    {
        if (squirrelRow == size - 1)
        {
            outOfBounds = true;
            Console.WriteLine("The squirrel is out of the field.");
            break;
        }
        else
        {
            squirrelRow++;
            if (field[squirrelRow, squirrelCol] == 'h')
            {
                field[squirrelRow, squirrelCol] = '*';
                hazelnutToCollect++;
            }
        }
    }
    else if (comands[i] == "up")
    {
        if (squirrelRow == 0)
        {
            outOfBounds = true;
            Console.WriteLine("The squirrel is out of the field.");
            break;
        }
        else
        {
            squirrelRow--;
            if (field[squirrelRow, squirrelCol] == 'h')
            {
                field[squirrelRow, squirrelCol] = '*';
                hazelnutToCollect++;
            }
        }
    }

    if (field[squirrelRow, squirrelCol] == 't')
    {
        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
        break;
    }

    if (hazelnutToCollect == 3)
    {
        Console.WriteLine("Good job! You have collected all hazelnuts!");
        break;
    }
}
if (hazelnutToCollect < hazelnutCount
    && field[squirrelRow, squirrelCol] != 't'
    && outOfBounds == false)
{
    Console.WriteLine("There are more hazelnuts to collect.");
}
Console.WriteLine($"Hazelnuts collected: {hazelnutToCollect}");




