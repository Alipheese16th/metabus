

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    int N = int.Parse(sr.ReadLine() ?? "");

    for (int i = 0; i < N; i++)
    {
        long input = long.Parse(sr.ReadLine() ?? "");

        bool gcp = findSosu(input);

        if (gcp) {
            sw.WriteLine(input);
        } else {
            sw.WriteLine(lastSosu(input));
        }


    }

    bool findSosu(long x) {

        if (x <= 1) return false;
        if (x <= 3) return true;
        if (x % 2 == 0 || x % 3 == 0) return false;

        for (long i = 5; i * i <= x; i += 6)
        {
            if (x % i == 0 || x % (i + 2) == 0) return false;
        }

        return true;

    }

    long lastSosu(long x) {


        while (true) {
        x++;

            if (findSosu(x)) {
                return x;
            }

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