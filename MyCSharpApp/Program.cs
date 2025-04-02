int n = int.Parse(Console.ReadLine());

List<int> intList = new();

for (int i = 0; i < n; i++)
{
    intList.Add(int.Parse(Console.ReadLine()));
}

intList.Sort();

intList.ForEach(x => Console.WriteLine(x));









