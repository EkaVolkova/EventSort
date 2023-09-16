using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Создайте консольное приложение, в котором будет происходить сортировка списка фамилий из пяти человек. 
/// Сортировка должна происходить при помощи события. Сортировка происходит при введении пользователем либо числа 1 (сортировка А-Я), либо числа 2 (сортировка Я-А).
/// Дополнительно реализуйте проверку введённых данных от пользователя через конструкцию TryCatchFinally с использованием собственного типа исключения.
/// </summary>
namespace EventSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаем экземпляр класса NumberReader
            NumberReader numberReader = new NumberReader();
            //Добавляем обработчик события
            numberReader.NumberEnteredEvent += SortArray;
            try
            {
                //Считываем данные
                numberReader.Read();
            }
            catch (Exception ex)
            {

                //Метод Read скорее всего вернет FormatException, но может вернуть и OverflowException
                Console.WriteLine("Ошибка ввода: {0}", ex.Message);
            }
        }
        /// <summary>
        /// Сортирует массив по выбранному методу сортировки 
        /// </summary>
        /// <param name="arrayWay">Метод сортировки: 1 (сортировка А-Я), сортировка Я-А)</param>
        static void SortArray(int arrayWay)
        {
            string[] words = { "the", "quick", "brown", "fox", "jumps" };
            IEnumerable<string> sortWords;
            if (arrayWay == 1)
            {
                sortWords = from word in words
                            orderby word.Substring(0, 1)
                            select word;
            }
            else
            {
                sortWords = from word in words
                            orderby word.Substring(0, 1) descending
                            select word;
            }

            foreach (var word in sortWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
