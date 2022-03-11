using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class Program
    {
        delegate void method();
        static void Main(string[] args)
        {
            Note[] TheMyNote = new Note[0];
            DateTime DT = new DateTime();
            int Year, Mounth, Day;

            string[] items = { "0.Заполнить для наглядности",
                               "1.Добавить Новую запись",
                               "2.Отобразить записную книжку",
                               "3.Отсортироовать по номеру",
                               "4.Отсортироовать по Дате рождения",
                               "5.Отсортироовать по фамилии",
                               "6.Поиск",
                               "7.Удалить запись",
                               "------------------------------------" };
            method[] methods = new method[] { Method0, Method1, Method2, Method3, Method4, Method5, Method6, Method7 };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult != items.Length - 1);

            void Method0()
            {
                Console.WriteLine("Выбрана опция 0");

                Note[] temp1 = new Note[5];
                temp1[0] = new Note(129451, "Герберт", new DateTime(1991, 4, 1));
                temp1[1] = new Note(123451, "Пушкин", new DateTime(1990, 6, 4));
                temp1[2] = new Note(658754, "Глуховский", new DateTime(1994, 2, 10));
                temp1[3] = new Note(798456, "Роулинг", new DateTime(1999, 9, 11));
                temp1[4] = new Note(751668, "Сапковский", new DateTime(1998, 2, 6));

                TheMyNote = temp1;

            }
            void Method1()
            {
                Console.WriteLine("Выбрана опция 1");

                Note[] temp = new Note[TheMyNote.Length + 1];

                temp[temp.Length - 1] = new Note();

                for (int i = 0; i < TheMyNote.Length; i++)
                    temp[i] = TheMyNote[i];
                Console.WriteLine("Введите номер телефона");
                int.TryParse(Console.ReadLine(), out temp[temp.Length - 1].PhoneNumber);
                Console.WriteLine("Введите фамилию");
                temp[temp.Length - 1].Surname = Console.ReadLine();
                Console.WriteLine("Введите год рождения");
                Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите месяц рождения");
                Mounth = int.Parse(Console.ReadLine());
                Console.WriteLine("День");
                Day = int.Parse(Console.ReadLine());
                DT = new DateTime(Year, Mounth, Day);

                temp[temp.Length - 1].Birthday = DT;

                TheMyNote = temp;
            }
            void Method2()
            {
                Console.WriteLine("Выбрана опция 2");

                Note.Display(TheMyNote);
            }
            void Method3()
            {
                Console.WriteLine("Выбрана опция 3");

                Note.NumberSort(TheMyNote);
                Note.Display(TheMyNote);
            }
            void Method4()
            {
                Console.WriteLine("Выбрана опция 4");

                Note.BirthdaySort(TheMyNote);
                Note.Display(TheMyNote);
            }
            void Method5()
            {
                Console.WriteLine("Выбрана опция 5");

                Note.SurNameSort(TheMyNote);
                Note.Display(TheMyNote);
            }
            void Method6()
            {
                Console.WriteLine("Выбрана опция 6");

                Console.WriteLine("Введите фимилию , или номер телефона");
                Note.SearchNote(TheMyNote, Console.ReadLine());
            }
            void Method7()
            {
                Console.WriteLine("Выбрана опция 7");

                Note.Display(TheMyNote);
                Console.WriteLine("Введите номер записи для удаления");
                int num = -1;
                int.TryParse(Console.ReadLine(), out num);

                if (num > 0 && num < TheMyNote.Length - 1)
                {
                    TheMyNote = Note.DeleteNote(TheMyNote, num - 1);
                }

                Note.Display(TheMyNote);
            }

        }
    }
}
