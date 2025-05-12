
using System.Text;

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());


// int[] input = (sr.ReadLine() ?? "").Split().Select(int.Parse).ToArray();
int N = int.Parse(sr.ReadLine() ?? "");
LinkedList<int> deque = new LinkedList<int>();

for (int i = 0; i < N; i++)
{
    string line = sr.ReadLine() ?? "";

    int spaceIdx = line.IndexOf(' ');
    int cmd = spaceIdx == -1 ? int.Parse(line) : int.Parse(line.AsSpan(0, spaceIdx));
    int value = spaceIdx == -1 ? 0 : int.Parse(line.AsSpan(spaceIdx + 1));

    
    switch (cmd)
    {
        case 1:
        deque.AddFirst(value);
        break;
        case 2:
        deque.AddLast(value);
        break;
        case 3:
        if (deque.Count > 0) {
            sw.WriteLine(deque.First());
            deque.RemoveFirst();
        } else {
            sw.WriteLine(-1);
        }
        break;
        case 4:
        if (deque.Count > 0) {
            sw.WriteLine(deque.Last());
            deque.RemoveLast();
        } else {
            sw.WriteLine(-1);
        }
        break;
        case 5:
        sw.WriteLine(deque.Count);
        break;
        case 6:
        int isEmpty = deque.Count == 0 ? 1 : 0;
        sw.WriteLine(isEmpty);
        break;
        case 7:
        if (deque.Count > 0) {
            sw.WriteLine(deque.First());
        } else {
            sw.WriteLine(-1);
        }
        break;
        case 8:
        if (deque.Count > 0) {
            sw.WriteLine(deque.Last());
        } else {
            sw.WriteLine(-1);
        }
        break;
    }
    
}



sr.Close();
sw.Close();
