
StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());


int N = int.Parse(sr.ReadLine() ?? "");
HashSet<string> set = new HashSet<string>();
int result = 0;

for (int i = 0; i < N; i++)
{
    string input = sr.ReadLine() ?? "";

    if ("ENTER".Equals(input))
    {
        result += set.Count;
        set.Clear();
    }
    else
    {
        set.Add(input);
    }

}
result += set.Count;

sw.Write(result);







sr.Close();
sw.Close();
