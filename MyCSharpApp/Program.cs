

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    int t = int.Parse(sr.ReadLine() ?? "");

    for (int x = 0; x < t; x++)
    {

        int n = int.Parse(sr.ReadLine() ?? "");

        bool[] isNotPrime = new bool[n+1];

        isNotPrime[0] = true;
        isNotPrime[1] = true;

        for (int i = 2; i*i <= n; i++)
        {
            for (int j = i*i; j <= n; j += i)
            {
                isNotPrime[j] = true;
            }
        }
        HashSet<(int, int)> ttt = new HashSet<(int, int)>();

        for (int i = 2; i <= n/2; i++) {
            if (!isNotPrime[i] && !isNotPrime[n-i]) {

                int first = i < (n-i) ? i : (n-i);
                int second = i > (n-i) ? i : (n-i);

                ttt.Add((i, n-i));
            }
        }

        sw.WriteLine(ttt.Count);

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