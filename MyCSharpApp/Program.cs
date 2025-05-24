
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
int result2 = list[list.Count / 2];
List<int> result3List = map.Where(pair => pair.Value == map.Values.Max()).Select(pair => pair.Key).OrderBy(n => n).ToList();
int result3 = result3List.Count > 1 ? result3List[1] : result3List[0];
int result4 = list.Max() - list.Min();

sw.WriteLine(result1);
sw.WriteLine(result2);
sw.WriteLine(result3);
sw.WriteLine(result4);

sr.Close();
sw.Close();
