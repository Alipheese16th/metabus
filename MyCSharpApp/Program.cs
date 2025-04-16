

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    // 이번문제는 에라토스테네스의 채 공식을 사용하는 예제다.
    // M ~ N 의 범위가 주어지면 해당 범위의 소수를 구하는 예제

    int[] input = (sr.ReadLine() ?? "").Split().Select(int.Parse).ToArray();

    int M = input[0];
    int N = input[1];

    bool[] isNotPrime = new bool[N+1]; // 기본 false 값으로 N까지의 index를 초기화

    isNotPrime[0] = true; // 소수가 아님
    isNotPrime[1] = true;

    for (int i = 2; i*i <= N; i++) // 2부터 N의제곱근까지 (합성수는 N의제곱근이하까지는 무조건 약수가 존재하기때문에)
    {
        for (int j = i*i; j <= N; j += i) // 약수의 배수들은 전부 소수가 아님
        {
            isNotPrime[j] = true;
        }
    }
    
    for (int i = M; i <= N; i++)
    {
        if (!isNotPrime[i])
        sw.WriteLine(i);
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