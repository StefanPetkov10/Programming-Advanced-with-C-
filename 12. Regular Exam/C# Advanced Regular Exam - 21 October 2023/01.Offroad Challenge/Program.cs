
Stack<int> initialFuel = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

Queue<int> additionalConsumption = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());


List<int> neededFuel = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int altitudeCount = 0;

bool breakProgramm = false;

for (int i = 0; i < neededFuel.Count; i++)
{
    int currentInitialFuel = initialFuel.Peek();
    int currentAdditionalConsumption = additionalConsumption.Peek();

    int currentAltitude = currentInitialFuel - currentAdditionalConsumption;

    if (currentAltitude >= neededFuel[i])
    {
        initialFuel.Pop();
        additionalConsumption.Dequeue();
        neededFuel.RemoveAt(i);
        i--;
        altitudeCount++;

        Console.WriteLine($"John has reached: Altitude {altitudeCount}");
    }
    else
    {
        breakProgramm = true;
        Console.WriteLine($"John did not reach: Altitude {altitudeCount + 1}");
        break;
    }

}


if (altitudeCount > 0 && breakProgramm)
{
    Console.WriteLine("John failed to reach the top.");
    string str = "Altitude";

    string output = "Reached altitudes: ";
    for (int i = 1; i <= altitudeCount; i++)
    {
        output += $"Altitude {i}";
        if (i < altitudeCount)
        {
            output += ", ";
        }
    }
    Console.WriteLine(output);

    //{
    //    int n = 10; // Replace 10 with your desired value for n
    //    string[] altitudes = Enumerable.Range(1, n).Select(i => $"Altitude {i}").ToArray();
    //    string output = "Reached altitudes: " + string.Join(", ", altitudes);
    //    Console.WriteLine(output);
    //}

    //Console.WriteLine($"Reached altitudes: Altitude {string.Join(" Altitude ", Enumerable.Range(1, altitudeCount))}");

    //    for (int i = 1; i <= altitudeCount; i++)
    //    {
    //        Console.Write($"Altitude {i}, ");
    //    }
}
else if (altitudeCount == 0)
{
    Console.WriteLine("John failed to reach the top.");
    Console.WriteLine("John didn't reach any altitude.");
}

if (!initialFuel.Any() && !additionalConsumption.Any() && !neededFuel.Any())
{
    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
}