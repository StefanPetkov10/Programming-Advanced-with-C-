
int size = int.Parse(Console.ReadLine());

int sumTons = 0;

bool lose = false;

char[,] field = new char[size, size];

int currentRow = -1;
int currentCol = -1;


for (int row = 0; row < size; row++)
{
    string currentRowInput = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        field[row, col] = currentRowInput[col];

        if (field[row, col] == 'S')
        {
            currentRow = row;
            currentCol = col;

            field[currentRow, currentCol] = '-';
        }
    }
}

string comands = string.Empty;

while ((comands = Console.ReadLine()) != "collect the nets")
{

    if (comands == "left")
    {
        if (currentCol == 0)
        {
            currentCol = size - 1;
            if (field[currentRow, currentCol] == 'W')
            {
                lose = true;
                break;
            }

            if (char.IsDigit(field[currentRow, currentCol]))
            {
                sumTons += field[currentRow, currentCol] - 48;
                field[currentRow, currentCol] = '-';
            }
        }
        else
        {
            currentCol--;

            if (field[currentRow, currentCol] == 'W')
            {
                lose = true;
                break;
            }

            if (char.IsDigit(field[currentRow, currentCol]))
            {
                sumTons += field[currentRow, currentCol] - 48;
                field[currentRow, currentCol] = '-';
            }
        }
    }
    else if (comands == "right")
    {
        if (currentCol == size - 1)
        {
            currentCol = 0;
            if (field[currentRow, currentCol] == 'W')
            {
                lose = true;
                break;
            }

            if (char.IsDigit(field[currentRow, currentCol]))
            {
                sumTons += field[currentRow, currentCol] - 48;
                field[currentRow, currentCol] = '-';
            }
        }
        else
        {
            currentCol++; ;

            if (field[currentRow, currentCol] == 'W')
            {
                lose = true;
                break;
            }

            if (char.IsDigit(field[currentRow, currentCol]))
            {
                sumTons += field[currentRow, currentCol] - 48;
                field[currentRow, currentCol] = '-';
            }
        }
    }
    else if (comands == "down")
    {
        if (currentRow == size - 1)
        {
            currentRow = 0;
                ;
            if (field[currentRow, currentCol] == 'W')
            {
                lose = true;
                break;
            }

            if (char.IsDigit(field[currentRow, currentCol]))
            {
                sumTons += field[currentRow, currentCol] - 48;
                field[currentRow, currentCol] = '-';
            }
        }
        else
        {
            currentRow++;

            if (field[currentRow, currentCol] == 'W')
            {
                lose = true;
                break;
            }

            if (char.IsDigit(field[currentRow, currentCol]))
            {
                sumTons += field[currentRow, currentCol] - 48;
                field[currentRow, currentCol] = '-';
            }
        }
    }
    else if (comands == "up")
    {
        if (currentRow == 0)
        {
            currentRow = size - 1;
            ;
            if (field[currentRow, currentCol] == 'W')
            {
                lose = true;
                break;
            }

            if (char.IsDigit(field[currentRow, currentCol]))
            {
                sumTons += field[currentRow, currentCol] - 48;
                field[currentRow, currentCol] = '-';
            }
        }
        else
        {
            currentRow--;

            if (field[currentRow, currentCol] == 'W')
            {
                lose = true;
                break;
            }

            if (char.IsDigit(field[currentRow, currentCol]))
            {
                sumTons += field[currentRow, currentCol] - 48;
                field[currentRow, currentCol] = '-';
            }
        }
    }
}

if (lose)
{
    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currentRow},{currentCol}]");
}

if (sumTons >= 20 && lose == false)
{
    Console.WriteLine("Success! You managed to reach the quota!");
}
else if(lose == false)
{
    Console.Write("You didn't catch enough fish and didn't reach the quota! ");
    Console.WriteLine($"You need {20 - sumTons} tons of fish more.");
}

if (sumTons > 0 && lose == false)
{
    Console.WriteLine($"Amount of fish caught: {sumTons} tons.");
}

if (lose == false)
{
    field[currentRow, currentCol] = 'S';

    for (int row = 0; row < field.GetLength(0); row++)
    {
        for (int col = 0; col < field.GetLength(1); col++)
        {
            Console.Write(field[row, col]);
        }
        Console.WriteLine();
    }
}
