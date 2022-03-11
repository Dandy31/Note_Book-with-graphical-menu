using System;
using System.Collections.Generic;
using System.Text;


namespace PhoneBook
{
    // Класс запись
    class Note
    {
        public int PhoneNumber;
        public string Surname;
        public DateTime Birthday;


        public Note()       // конструктор по умолчанию
        {
        }


        public Note(int _PhoneNumber, string _Surname, DateTime _Birthday)   // Конструктор класса
        {
            PhoneNumber = _PhoneNumber;
            Surname = _Surname;
            Birthday = _Birthday;

        }


        // функция вывода на экрам записной книги
        public static void Display(Note[] MyNote)
        {
            if (MyNote.Length != 0)
                for (int i = 0; i < MyNote.Length; i++)
                    Console.WriteLine("{3} : Фамилия {0} , Дата рождения {1} , Номер телефона {2}", MyNote[i].Surname, MyNote[i].Birthday, MyNote[i].PhoneNumber, i + 1);
            else
                Console.WriteLine("Записная книга пуста");
        }




        public static void NumberSort(Note[] MyNote)  // сортировка по номеру
        {
            Array.Sort(MyNote, LogicSortNumber);
        }


        public static void BirthdaySort(Note[] MyNote)  // сортировка по дате рождения
        {
            Array.Sort(MyNote, LogicSortBirthday);
        }

        public static void SurNameSort(Note[] MyNote)// сортировка по фамилии
        {
            Array.Sort(MyNote, LogicSortSurName);
        }



        static int LogicSortNumber(Note x, Note y)
        {
            if (x.PhoneNumber < y.PhoneNumber) return -1; //порядок соблюден
            if (x.PhoneNumber > y.PhoneNumber) return +1; //порядок нарушен
            return 0; // безразличие

        }

        static int LogicSortBirthday(Note x, Note y)
        {
            if (x.Birthday < y.Birthday) return -1; //порядок соблюден
            if (x.Birthday > y.Birthday) return +1; //порядок нарушен
            return 0; // безразличие
        }



        static int LogicSortSurName(Note x, Note y)
        {
            int i = 0;

            while (i < x.Surname.Length && i < y.Surname.Length)
            {

                if (x.Surname[i] < y.Surname[i]) return -1; //порядок соблюден
                if (x.Surname[i] > y.Surname[i]) return +1; //порядок нарушен
                i++;
            }
            if (x.Surname.Length < y.Surname.Length) return -1; //порядок соблюден
            if (x.Surname.Length > y.Surname.Length) return +1; //порядок нарушен
            return 0;


        }



        // Поиск по номеру или фамилии 
        public static void SearchNote(Note[] MyNote, string search)
        {
            int number = 0;
            bool flag = int.TryParse(search, out number);

            for (int i = 0; i < MyNote.Length; i++)
            {

                if (flag)
                    if (MyNote[i].PhoneNumber == int.Parse(search)) // Поиск по номеру
                    {
                        Console.WriteLine("Фамилия {0} , Дата рождения {1} , Номер телефона {2}", MyNote[i].Surname, MyNote[i].Birthday, MyNote[i].PhoneNumber);
                        number++;
                    }
                if (!flag)
                    if (MyNote[i].Surname == search) // Поиск по имени
                    {
                        Console.WriteLine("Фамилия {0} , Дата рождения {1} , Номер телефона {2}", MyNote[i].Surname, MyNote[i].Birthday, MyNote[i].PhoneNumber);
                        number++;
                    }
            }

            if (number == 0) // Если пустая книга
                Console.WriteLine("Нет записей с искомыми параметрами");



        }


        // удаление из записной книжки 
        public static Note[] DeleteNote(Note[] MyNote, int numberNote)
        {
            Note[] temp = new Note[MyNote.Length - 1];
            int k = 0;

            for (int i = 0; i < MyNote.Length; i++)
            {
                if (i == numberNote)
                    continue;
                temp[k++] = MyNote[i];

            }

            return temp;

        }

    }

}
