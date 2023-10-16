namespace PassswordReader
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PassswordReader passswordReader = new PassswordReader();
            int passwordCount = passswordReader.Read("../../../Files/password.txt").Count;

            Console.WriteLine(passwordCount);
        }
    }
}