using System;

/// <summary>
/// Создайте консольное приложение, в котором будет происходить сортировка списка фамилий из пяти человек. 
/// Сортировка должна происходить при помощи события. Сортировка происходит при введении пользователем либо числа 1 (сортировка А-Я), либо числа 2 (сортировка Я-А).
/// Дополнительно реализуйте проверку введённых данных от пользователя через конструкцию TryCatchFinally с использованием собственного типа исключения.
/// </summary>
namespace EventSort
{
    class NumberReader
    {
        //Делегат для оповещении о наступлении события
        public delegate void NumberEnteredDelegate(int num);
        //Событие ввода пользователем способа сортировки
        public event NumberEnteredDelegate NumberEnteredEvent;

        /// <summary>
        /// Считывание давннх о введенном пользователем методе сортировки
        /// </summary>
        public void Read()
        {
            Console.WriteLine("Введите число 1 (сортировка А-Я) или число 2 (сортировка Я-А)");
            
            //Считываем из консоли сивол
            int num = int.Parse(Console.ReadLine());

            //проверяем, что было введено 1 или 2
            if (num != 1 && num != 2)
                throw new EnteredException();

            //Вызываем оповещение о событии
            NumberEntered(num);

        }

        /// <summary>
        /// Метод, вызывающий событие
        /// </summary>
        /// <param name="num">способ сортировки</param>
        private void NumberEntered(int num)
        {
            NumberEnteredEvent?.Invoke(num);
        }
    }
}
