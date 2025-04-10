

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    int[] input = (sr.ReadLine() ?? "").Split().Select(x => int.Parse(x)).ToArray();

    int a1 = input[0];
    int b1 = input[1];

    int[] input2 = (sr.ReadLine() ?? "").Split().Select(x => int.Parse(x)).ToArray();

    int a2 = input2[0];
    int b2 = input2[1];

    int resultA;
    int resultB;

    if (b1 != b2) {

        int sumA = a1*b2 + a2*b1;
        int gcd = findGCD(sumA, b1*b2);

        resultA = sumA/gcd;
        resultB = b1*b2/gcd;
        
    } else {

        int sumA = a1 + a2;
        int gcd = findGCD(sumA, b1);

        resultA = sumA/gcd;
        resultB = b1/gcd;

    }

    sw.WriteLine(resultA + " " + resultB);

    int findGCD (int x, int y) {
        return x%y == 0 ? y : findGCD(y, x%y);
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