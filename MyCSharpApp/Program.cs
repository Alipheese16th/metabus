
StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());


int[] input = (sr.ReadLine() ?? "").Split().Select(int.Parse).ToArray();
int N = input[0];
int M = input[1];

Dictionary<string, int> map = new Dictionary<string, int>();

for (int i = 0; i < N; i++)
{
    string word = sr.ReadLine() ?? "";

    if (map.ContainsKey(word)) {
        map[word]++;
    } else {
        map[word] = 1;
    }

}

List<string> list = map.Where(x => x.Key.Length >= M)
                       .OrderByDescending(x => x.Value)
                       .ThenByDescending(x => x.Key.Length)
                       .ThenBy(x => x.Key)
                       .Select(x => x.Key)
                       .ToList();

list.ForEach(sw.WriteLine);


sr.Close();
sw.Close();
