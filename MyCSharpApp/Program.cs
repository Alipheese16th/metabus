
StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());


int input = int.Parse(sr.ReadLine() ?? "");

sw.WriteLine(fibonacci(input));

int fibonacci(int N) {

    if (N == 1) {
        return 1;

    } else if (N <= 0) {
        return 0;
    } else {
        return fibonacci(N-1) + fibonacci(N-2);
    }
}


sr.Close();
sw.Close();
