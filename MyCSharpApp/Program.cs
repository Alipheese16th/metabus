
StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());


int N = int.Parse(sr.ReadLine() ?? "");

int min, max;

List<int> list = (sr.ReadLine() ?? "").Split().Select(int.Parse).ToList();
min = list.Min();
max = list.Max();

sw.Write(min * max);


sr.Close();
sw.Close();
