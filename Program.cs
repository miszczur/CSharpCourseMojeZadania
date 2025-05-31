
class Program
{
    public static string ToKebabCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "Input is null or empty.";
        var kebabCase = new System.Text.StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (char.IsUpper(c))
            {
                if (i > 0 && (char.IsLower(input[i - 1]) || char.IsDigit(input[i - 1])))
                {
                    kebabCase.Append('-');
                }
                kebabCase.Append(char.ToLower(c));
            }
            else
            {
                kebabCase.Append(c);
            }
        }
        return kebabCase.ToString();
    }
    public static string ToCamelCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        var camelCase = new System.Text.StringBuilder();
        bool nextUpper = false;
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (c == '-')
            {
                nextUpper = true;
            }
            else
            {
                if (nextUpper)
                {
                    camelCase.Append(char.ToUpper(c));
                    nextUpper = false;
                }
                else
                {
                    camelCase.Append(c);
                }
            }
        }
        return camelCase.ToString();
    }
    static void Main(string[] args)
    {
        string kebabInput = "Hello-World-This-Is-Kebab-Case";
        string camelInput = "HelloWorldThisIsCamelCase";
        Console.WriteLine(ToKebabCase(camelInput));
        Console.WriteLine(ToCamelCase(kebabInput));

        //Zadania będą na oddzielnych branchach
    }
}


