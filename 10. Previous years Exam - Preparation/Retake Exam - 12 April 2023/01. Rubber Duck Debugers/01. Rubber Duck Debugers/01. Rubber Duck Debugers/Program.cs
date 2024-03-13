using System.Threading.Tasks;

Queue<int> times = new Queue<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

Stack<int> numberOfTasks  = new Stack<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<string, int> ducks = new()
            {
                {"Darth Vader Ducky", 0},
                {"Thor Ducky", 0},
                {"Big Blue Rubber Ducky", 0},
                {"Small Yellow Rubber Ducky", 0 }
            };

while (times.Any() && numberOfTasks.Any())
{
    int sum = times.Peek() * numberOfTasks.Peek();

    if ((sum >= 0) && (sum <= 240))
    {
        if ((sum >= 0) && (sum <= 60))
        {
            ducks["Darth Vader Ducky"]++;
        }
        else if ((sum >= 61) && (sum <= 120))
        {
            ducks["Thor Ducky"]++;
        }
        else if ((sum >= 121) && (sum <= 180))
        {
            ducks["Big Blue Rubber Ducky"]++;
        }
        else if ((sum >= 181) && (sum <= 240))
        {
            ducks["Small Yellow Rubber Ducky"]++;
        }
        times.Dequeue();
        numberOfTasks.Pop();
        continue;
    }
    else
    {
        numberOfTasks.Push(numberOfTasks.Pop() - 2);
        times.Enqueue(times.Dequeue());
    }
}
Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

foreach (var duck in ducks)
{
    Console.WriteLine($"{duck.Key}: {duck.Value}");
}