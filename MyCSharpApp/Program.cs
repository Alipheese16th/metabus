
string[] input = Console.ReadLine().Split();

int n = int.Parse(input[0]);
int k = int.Parse(input[1]);

List<int> intList = new();

string[] inputSecond = Console.ReadLine().Split();


for (int i = 0; i < n; i++)
{
    intList.Add(int.Parse(inputSecond[i]));
}

intList.Sort((a, b) => b.CompareTo(a));

Console.WriteLine(intList[k-1]);




