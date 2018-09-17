using System;

namespace httpError
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            HTTPErrorsCollection logErrors = new HTTPErrorsCollection();
            logErrors.ReadLogOfErrorsFromFile("File1.txt");
            Console.WriteLine(logErrors);
            Console.WriteLine();

            HTTPErrorsCollection fromFile = new HTTPErrorsCollection();
            MyTextPair text = fromFile.ReadTextFromFile("File2.txt");
            Console.WriteLine($"Text from file:\n{text.OldText}\nChanged text:\n{text.NewText}");
            Console.WriteLine();
        }
    }
}
