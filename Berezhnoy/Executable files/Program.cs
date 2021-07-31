using System;
using System.Collections.Generic;
using System.Linq;
using Berezhnoy.Extensions;
using Berezhnoy.Models;

namespace Berezhnoy.ExecutableFiles
{

    class Program
    {

        #region Delegates

        public delegate int DictionaryOrderDelegate(KeyValuePair<string, int> x);

        #endregion

        static void Main(string[] args)
        {

            while (true)
            {

                // 0. Preparations
                // 0.1. Greet the User
                Console.WriteLine("Домашняя работа №5.");
                Console.WriteLine();
                Console.WriteLine("Задание 2 - Метод расширения для строки");
                Console.WriteLine("Задание 3 - Подсчет количества элементов в коллекции");
                Console.WriteLine("Задание 4 - Сортровка словаря");

                string User_Task = Enter_Data_String("Введите номер задания. Введите q для выхода из программы: ");

                switch (User_Task)
                {

                    case "q":

                        // Quit the game
                        return;

                    case "2":

                        Task_2();

                        break;

                    case "3":

                        Task_3();

                        break;

                    case "4":

                        Task_4();

                        break;

                    default:

                        Console.WriteLine();
                        Console.WriteLine("Введено некорректное значение.");

                        break;

                };

                // Stop and show the user the result of his manipulations
                Console_Pause_And_Clear();

            };

        }

        #region Task 2

        public static void Task_2()
        {

            Console.Clear();

            var userString = Enter_Data_String("Введите строку: ");

            Console.WriteLine($"Symbols quantity in \"{userString}\" equals to {userString.SymbolsQuantity()}."); 

        }
                
        #endregion

        #region Task 3

        public static void Task_3()
        {

            // First example
            var intCollection = new List<int>();

            intCollection.Add(1);
            intCollection.Add(10);
            intCollection.Add(2);
            intCollection.Add(1);
            intCollection.Add(7);
            intCollection.Add(10);
            intCollection.Add(1);
            intCollection.Add(4);
            intCollection.Add(1);
            intCollection.Add(5);
            intCollection.Add(8);
            intCollection.Add(5);
            intCollection.Add(6);
            intCollection.Add(1);

            UniqueElementsQuantity(intCollection);

            // Second example
            var stringCollection = new List<string>();

            stringCollection.Add("way");
            stringCollection.Add("hey");
            stringCollection.Add("and");
            stringCollection.Add("up");
            stringCollection.Add("she");
            stringCollection.Add("rises");
            stringCollection.Add("way");
            stringCollection.Add("hey");
            stringCollection.Add("and");
            stringCollection.Add("up");
            stringCollection.Add("she");
            stringCollection.Add("rises");
            stringCollection.Add("way");
            stringCollection.Add("hey");
            stringCollection.Add("and");
            stringCollection.Add("up");
            stringCollection.Add("she");
            stringCollection.Add("rises");
            stringCollection.Add("early");
            stringCollection.Add("in");
            stringCollection.Add("the");
            stringCollection.Add("morning");

            UniqueElementsQuantity(stringCollection);

            // Third example
            var studentCollection = new List<Student>();

            studentCollection.Add(new Student("Никита", "Смирнов", "ФИНЭК", "экономический", "науч", 20, 4, 3, "Санкт - Петербург"));
            studentCollection.Add(new Student("Дмитрий", "Алексеев", "СПБГУ", "филологический", "английский язык", 23, 6, 2, "Пермь"));
            studentCollection.Add(new Student("Екатерина", "Семенова", "ФИНЭК", "экономический", "науч", 22, 1, 2, "Москва"));
            studentCollection.Add(new Student("Валерий", "Семенов", "СПБГУ", "филологический", "скандинавские языки", 23, 6, 1, "Москва"));
            studentCollection.Add(new Student("Никита", "Смирнов", "ФИНЭК", "экономический", "науч", 20, 4, 3, "Санкт - Петербург"));
            studentCollection.Add(new Student("Геннадий", "Чебурашкин", "СПБГУ", "экономический", "бухгалтерия", 18, 1, 3, "Сызрань"));
            studentCollection.Add(new Student("Алена", "Савина", "СПБГАСУ", "архитектурный", "ландшафтный дизайн", 19, 1, 3, "Санкт - Петербург"));

            UniqueElementsQuantity(studentCollection);
            
        }

        public static void UniqueElementsQuantity<T>(List<T> collection)
        {

            Console.WriteLine();
            Console.Write("Original collection: ");

            var separator = "";

            foreach(T element in collection)
            {

                Console.Write($"{separator}{element}");

                separator = ", ";

            };

            Console.WriteLine();
            Console.WriteLine();

            var groupedCollection = (from element
                                    in collection
                                    group element
                                    by element.ToString());

            foreach(IGrouping <string, T> group in groupedCollection)
            {

                Console.WriteLine($"Quantity of {group.Key} = {group.Count()}");

            };

        }

        #endregion

        #region

        public static void Task_4()
        {

            Dictionary<string, int> dictionary = new Dictionary<string, int>() {
                                
                {"four", 4},
                {"two", 2},
                {"one", 1},
                {"three", 3}

            };

            Task_4_OriginalOrder(dictionary.Clone());
            Task_4_OriginalOrder(dictionary.Clone());
            Task_4_OriginalOrder(dictionary.Clone());
            
        }
        public static void Task_4_OriginalOrder(Dictionary<string, int> dictionary)
        {

            var orderedDictionary = dictionary.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });

            Task_4_Output(orderedDictionary, "Original mode");

        }

        public static void Task_4_LambdaOrder(Dictionary<string, int> dictionary)
        {

            var orderedDictionary = dictionary.OrderBy(pair =>
            {

                return pair.Value;

            });

            Task_4_Output(orderedDictionary, "Lambda mode");

        }


        public static void Task_4_DelegateOrder(Dictionary<string, int> dictionary)
        {

            var orderedDictionary = dictionary.OrderBy(Task_4_Order);

            Task_4_Output(orderedDictionary, "Delegate mode");

        }
        
        public static int Task_4_Order(KeyValuePair<string, int> pair)
        {

            return pair.Value;

        }

        public static void Task_4_Output(IOrderedEnumerable<KeyValuePair<string, int>> dictionary, string orderMode)
        {

            Console.WriteLine(orderMode);
            Console.WriteLine();
            
            foreach (var pair in dictionary)
            {

                Console.WriteLine($"{pair.Key} - {pair.Value}");

            };
            
            Console.WriteLine();
            
        }


        #endregion


        #region Common methods

        /// <summary>
        ///  Method outputs message and prompts user to type value
        /// </summary>
        /// <param name="User_Question">Message, clarifying task for the User</param>
        /// <returns>User's answer to the question</returns>
        static string Enter_Data_String(string User_Question)
        {

            // 0. Variables
            string User_Answer;

            // 1. Ask the question
            Console.Write(User_Question);

            // 2. User data input
            User_Answer = Console.ReadLine();

            return User_Answer;

        }

        /// <summary>
        /// Method pauses code execution and let user to estimate everything that has been done in the code so far
        /// </summary>
        static void Console_Pause_And_Clear()
        {

            Console.WriteLine();
            Console.WriteLine("Нажмите Enter, чтобы продолжить...");

            // Pause in order not to close application
            Console.ReadLine();

            // Clear window for another programm
            Console.Clear();

        }

        #endregion

    }
    
}