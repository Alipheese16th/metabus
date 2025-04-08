

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{
   string input = sr.ReadLine() ?? "";

    HashSet<string> map = new HashSet<string>();

    for (int i = 1; i <= input.Length; i++) // 1 2 3 4 5
    {
        for (int j = 0; j + i <= input.Length; j++) 
        {
            map.Add(input.Substring(j, i));
        }
        
    }

    sw.WriteLine(map.Count);

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


