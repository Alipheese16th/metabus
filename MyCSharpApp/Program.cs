

StreamReader sr = new(Console.OpenStandardInput());
StreamWriter sw = new(Console.OpenStandardOutput());

try
{

    while (true) {

        string input = sr.ReadLine() ?? "";
        if ("." == input) {
            break;
        }
        string line = input.Substring(0, input.LastIndexOf('.'));
        Stack<char> stack = new Stack<char>();
        bool result = true;

        foreach (var item in line)
        {
            if ('['.Equals(item) || '('.Equals(item)) {
                stack.Push(item);
            } else if (']'.Equals(item)) {
                if (stack.Count == 0 || !'['.Equals(stack.Peek())) {
                    result = false;
                } else {
                    stack.Pop();
                }
            } else if (')'.Equals(item)) {
                if (stack.Count == 0 || !'('.Equals(stack.Peek())) {
                    result = false;
                } else {
                    stack.Pop();
                }
            }

        }

        if (stack.Count != 0) {
            result = false;
        }

        string comment = result ? "yes" : "no";
        sw.WriteLine(comment);


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