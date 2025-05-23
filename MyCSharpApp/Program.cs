
StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());


int N = int.Parse(sr.ReadLine() ?? "");
Dictionary<int, int> map = new Dictionary<int, int>();


for (int i = 0; i < N; i++) {
    int input = int.Parse(sr.ReadLine() ?? "");

    if (map.ContainsKey(input)) {
        map[input]++;
    } else {
        map[input] = 1;
    }

}

List<int> list = map.SelectMany(pair => Enumerable.Repeat(pair.Key, pair.Value)).ToList();
list.Sort();

int result1 = (int)Math.Round(list.Average());
int result2 = list[list.Count / 2 + 1];
List<int> result3List = map.Where(pair => pair.Value == map.Values.Max()).OrderBy(n => n).ToList();



sr.Close();
sw.Close();
