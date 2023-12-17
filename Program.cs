using Labb3Skolan.Controllers;

namespace Labb3Skolan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunController runController = new RunController();
            runController.Run();
        }
    }
}