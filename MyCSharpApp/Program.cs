

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    if (!int.TryParse(sr.ReadLine() ?? "", out int N)) {
        Console.WriteLine("숫자만 입력하세요오오");
        Environment.Exit(0);
    }

    Stack<int> stack = new Stack<int>();
    int nextInt = 1;

    int[] list = (sr.ReadLine() ?? "").Split().Select(int.Parse).ToArray();

    foreach (var item in list)
    {
        if (item == nextInt) {
            nextInt++;
        } else {
            stack.Push(item);
        }

        while (stack.Count > 0 && stack.Peek() == nextInt) {
            stack.Pop();
            nextInt++;
        }
        
    }
    
    while (stack.Count > 0 && stack.Peek() == nextInt) {
        stack.Pop();
        nextInt++;
    }

    string result = nextInt == N + 1 ? "Nice" : "Sad";
    Console.WriteLine(result);



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