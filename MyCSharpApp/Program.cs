StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    int N = int.Parse(sr.ReadLine());
    List<string> list = new List<string>();

    for (int i = 0; i < N; i++)
    {
        list.Add(sr.ReadLine());
    }
    list = list.Distinct().ToList();
    list.Sort((a, b) => {
        if (a.Length == b.Length) {
            return a.CompareTo(b);
        } else {
            return a.Length.CompareTo(b.Length);
        }
    });

    list.ForEach(sw.WriteLine);



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
