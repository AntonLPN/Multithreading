using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class Menu
    {
        public int menu()
        {
            int menu = 0;
            int i = 0;

            Console.WriteLine("   1- Task #1");
            Console.WriteLine("   2- Task #2");
            Console.WriteLine("   3- Task #2");
            Console.WriteLine("   4- Task #4");
            Console.WriteLine("   5- Exit");
         

            Console.SetCursorPosition(0, i);//настраиваем полежение курсора слева
            Console.Write("=>");
            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(0, 8);
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (i > 0)
                            {
                                i--;
                                Console.SetCursorPosition(0, i);
                                Console.Write("=>");
                                Console.SetCursorPosition(0, i + 1);
                                Console.Write("  ");

                            }
                            break;

                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (i < 4)//так как пунктов меню 7 а отчет с нуля то пишем 6
                            {
                                i++;
                                Console.SetCursorPosition(0, i);
                                Console.Write("=>");
                                Console.SetCursorPosition(0, i - 1);
                                Console.Write("  ");
                            }
                            break;

                        }

                }

                key = Console.ReadKey().Key;
            }


            menu = i + 1;

            return menu;
        }
    }
}
