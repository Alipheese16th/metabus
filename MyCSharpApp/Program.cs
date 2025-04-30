

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    if (!int.TryParse(sr.ReadLine() ?? "", out int N)) {
        Console.WriteLine("숫자만 입력하세요오오");
        Environment.Exit(0);
    }

    Queue<int> que = new Queue<int>();

    for (int i = 0; i < N; i++)
    {
        string[] input = (sr.ReadLine() ?? "").Split();
        string keyword = input[0];
        switch (keyword)
        {
            case "push":
            break;
            case "pop":
            break;
            case "size":
            break;
            case "empty":
            break;
            case "front":
            break;
            case "back":
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