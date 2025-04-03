StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    int N = int.Parse(sr.ReadLine());

    List<(int x, int y)> list = new();
    // ValueTuple 타입의 리스트

    for (int i = 0; i < N; i++)
    {
        string[] input = sr.ReadLine().Split();
        list.Add((int.Parse(input[0]), int.Parse(input[1])));
        
    }

    list.Sort();
    // ValueTuple 은 기본적으로 Comparable 을 구현하고있음
    
    list.ForEach(item=>sw.WriteLine(item.x + " " + item.y));




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
