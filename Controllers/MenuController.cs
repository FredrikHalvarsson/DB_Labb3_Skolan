using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Skolan.Controllers
{
    static class MenuController
    {
        public static int Menu(string option1, string option2)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[0m to select:");
            Console.WriteLine("\u001b[32mPlease make a choice\u001b[0m\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "  ")}1 {option1}\u001b[0m");
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}2 {option2}\u001b[0m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 2 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 2 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.Clear();
            Console.CursorVisible = true;
            return option;
        }
        public static int Menu(string option1, string option2, string option3)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[0m to select:");
            Console.WriteLine("\u001b[32mPlease make a choice\u001b[0m\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "  ")}1 {option1}\u001b[0m");
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}2 {option2}\u001b[0m");
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}3 {option3}\u001b[0m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 3 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 3 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.Clear();
            Console.CursorVisible = true;
            return option;
        }
        public static int Menu(string option1, string option2, string option3, string option4)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[0m to select:");
            Console.WriteLine("\u001b[32mPlease make a choice\u001b[0m\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "  ")}1 {option1}\u001b[0m");
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}2 {option2}\u001b[0m");
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}3 {option3}\u001b[0m");
                Console.WriteLine($"{(option == 4 ? decorator : "  ")}4 {option4}\u001b[0m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 4 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 4 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.Clear();
            Console.CursorVisible = true;
            return option;
        }
        public static int Menu(string option1, string option2, string option3, string option4,string option5)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[0m to select:");
            Console.WriteLine("\u001b[32mPlease make a choice\u001b[0m\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "  ")}1 {option1}\u001b[0m");
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}2 {option2}\u001b[0m");
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}3 {option3}\u001b[0m");
                Console.WriteLine($"{(option == 4 ? decorator : "  ")}4 {option4}\u001b[0m");
                Console.WriteLine($"{(option == 5 ? decorator : "  ")}5 {option5}\u001b[0m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 5 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 5 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.Clear();
            Console.CursorVisible = true;
            return option;
        }
        public static int Menu(string option1, string option2, string option3, string option4, string option5, string option6)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[0m to select:");
            Console.WriteLine("\u001b[32mPlease make a choice\u001b[0m\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "  ")}1 {option1}\u001b[0m");
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}2 {option2}\u001b[0m");
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}3 {option3}\u001b[0m");
                Console.WriteLine($"{(option == 4 ? decorator : "  ")}4 {option4}\u001b[0m");
                Console.WriteLine($"{(option == 5 ? decorator : "  ")}5 {option5}\u001b[0m");
                Console.WriteLine($"{(option == 6 ? decorator : "  ")}6 {option6}\u001b[0m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 6 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 6 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.Clear();
            Console.CursorVisible = true;
            return option;
        }
    }
}
