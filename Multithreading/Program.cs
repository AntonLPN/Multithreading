using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class StartEnd
    {
        public int start;
        public int end;

        public StartEnd()
        {
            start = 0;
            end = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Menu menuClass = new Menu();//клас для работы с меню а именно преребор стрелками по меню
            int menu = 0;
            do
            {
               
                Console.WriteLine("Enter number to choice task");
                Console.WriteLine("   1- Task #1");
                Console.WriteLine("   2- Task #2");
                Console.WriteLine("   3- Task #2");
                Console.WriteLine("   4- Task #4");
                Console.WriteLine("   5- Exit");
                Console.Write(">>");
                Int32.TryParse(Console.ReadLine(), out menu) ;


              
                switch (menu)
                {
                    
                    //Task1-------------------------------
//                    Задание №1
//Создайте консольное приложение, порождающее поток. Этот поток должен
//отображать в консоль числа от 0 до 50.
                    case 1:
                        {
                      
                            ThreadStart threadStart = new ThreadStart(MethodTask1);
                            Thread thread = new Thread(threadStart);

                            thread.Start();

                            



                        }break;
                        //-------------------------------------------------------------------
                        //Task2
//                        Задание №2
//Добавьте в первое задание возможность передачи начала и конца диапазона
//чисел.Границы определяет пользователь.
                    case 2:
                        {

                            StartEnd startEnd = new StartEnd();
                            Console.Write("Enter begin value >>");
                            Int32.TryParse(Console.ReadLine(), out startEnd.start);
                            Console.Write("Enter end value >>");
                            Int32.TryParse(Console.ReadLine(), out startEnd.end);

                            MethodTask2(startEnd);



                        }
                        break;
                        //----------------------------------------------
                        //Task3
//                        Задание №3
//Создайте поток, который "принимает" в себя коллекцию элементов, и
//вызывает из каждого элемента коллекции метод ToString() и выводит результат
//работы метода на экран.
                    case 3:
                        {
                            //Создание объекта для генерации чисел
                            Random rnd = new Random();

                           int []arr=new int[20];

                            for (int i = 0; i < arr.Length; i++)
                            {
                                arr[i]= rnd.Next(0, 10);   //Получить случайное число (в диапазоне от 0 до 10)
                            }

                            MethodTask3(arr);


                        }
                        //-----------------------------------------------------
//                        Задание №4
//Консольное приложение генерирует набор чисел, состоящий из 10000
//элементов.С помощью механизма потоков нужно найти максимум, минимум,
//среднее в этом наборе.
//Для каждой из задач выделите поток.
                        break;
                    case 4:
                        {
                            Random rnd = new Random();

                            int[] arr = new int[10];

                            for (int i = 0; i < arr.Length; i++)
                            {
                                arr[i] = rnd.Next(0, 10000);   //Получить случайное число (в диапазоне от 0 до 10000)
                            }
                            Console.WriteLine("Values array for debug information");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(arr[i] + "|");
                            }
                            Console.WriteLine();
                            MaxMinMidl(arr);


                        }
                        break;




                    default:
                        break;
                }




            } while (menu!=5);






        }

        static void MethodTask1()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine($"Thred {i}");
            }


        }

        static void MethodTask2(Object parametrs)
        {
            StartEnd startEnd = parametrs as StartEnd;
             


            for (int i = startEnd.start; i <=startEnd.end; i++)
            {
                Console.WriteLine($"Thred task2 {i}");
            }


        }

        static void MethodTask3(Object obj)
        {
            var arr = obj as Array;

            foreach (var item in arr)
            {
                Console.Write(item.ToString() + " |");
            }
            Console.WriteLine();


        }
        static void MaxMinMidl(int []arr)
        {
            //поток минимального значения
            ThreadStart threadMin = new ThreadStart(()=>Min(arr));
            Thread thread1 = new Thread(threadMin);
            thread1.Start();

            //поток максимального значения
            ThreadStart threadMax = new ThreadStart(() => Max(arr));
            Thread thread2 = new Thread(threadMax);
            thread2.Start();

            //поток среднего значения
            ThreadStart threadMid = new ThreadStart(() => Midl(arr));
            Thread thread3 = new Thread(threadMid);
            thread3.Start();
        }

        static void Max(int []arr)
        {
            int max = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]>max)
                {
                    max = arr[i];
                }
            }

            Console.WriteLine($"Maximum array value is : {max}");
        }
        static void Min(int[] arr)
        {
            int min = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine($"Minimum array value is : {min}");
        }

        static void Midl(int[] arr)
        {
            int midl = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                midl += arr[i];
            }
            midl = midl / arr.Length;
            Console.WriteLine($"Midl array value is : {midl}");
        }
    }
}
