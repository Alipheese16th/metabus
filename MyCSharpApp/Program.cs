

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    if (!int.TryParse(sr.ReadLine() ?? "", out int N)) {
        Console.WriteLine("숫자만 입력하세요오오");
        Environment.Exit(0);
    }

    Queue<int> que = new Queue<int>();
    int lastInput = 0;

    for (int i = 0; i < N; i++)
    {
        string[] input = (sr.ReadLine() ?? "").Split();
        string keyword = input[0];

        switch (keyword)
        {
            case "push":
            que.Enqueue(int.Parse(input[1]));
            lastInput = int.Parse(input[1]);
            break;
            case "pop":
            int pop = que.Count == 0 ? -1 : que.Dequeue();
            sw.WriteLine(pop);
            break;
            case "size":
            sw.WriteLine(que.Count);
            break;
            case "empty":
            int isEmpty = que.Count == 0 ? 1 : 0;
            sw.WriteLine(isEmpty);
            break;
            case "front":
            int first = que.Count == 0 ? -1 : que.Peek();
            sw.WriteLine(first);
            break;
            case "back":
            int last = que.Count == 0 ? -1 : lastInput;
            sw.WriteLine(last);
            break;
        }

    }



}
catch (Exception ex)
{
    sw.WriteLine(ex.Message);
}
finally
{
    sr.Close();
    sw.Close();
}