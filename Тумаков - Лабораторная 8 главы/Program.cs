using Тумаков___Лабораторная_8_главы;
using Тумаков___Лабораторная_8_главы.Classes;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class Programm
{
    public static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }
    public static void Task1()
    {
        Console.WriteLine("Упражнение 8.1\n");
        //В класс банковский счет, созданный в упражнениях 7.1 - 7.3 добавить
        //метод, который переводит деньги с одного счета на другой.У метода два параметра: ссылка
        //на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.

        BankAccount account1 = new BankAccount(AccountType.Текущий, 1000);

        account1.ShowAccountInfo();
        account1.Withdraw(500);
        account1.Deposit(200);

        BankAccount account2 = new BankAccount(AccountType.Накопительный, 500);

        account2.ShowAccountInfo();

        account1.Transfer(account1, account2, 300);

        account1.ShowAccountInfo();
        account2.ShowAccountInfo();
    }
    
    public static string ReverseString(string input)
    {
        try
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        catch(ArgumentNullException)
        {
            return $"Входная строка не может быть null";
        }
    }
    public static void Task2()
    {
        Console.WriteLine("\nУпражнение 8.2\n");
        //Реализовать метод, который в качестве входного параметра принимает
        //строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
        //Протестировать метод.

        string testString1 = "It's snowing!";
        string reversedString1 = ReverseString(testString1);
        Console.WriteLine($"Исходная строка: {testString1}");
        Console.WriteLine($"Перевернутая строка: {reversedString1}");

        string testString2 = "12345";
        string reversedString2 = ReverseString(testString2);
        Console.WriteLine($"Исходная строка: {testString2}");
        Console.WriteLine($"Перевернутая строка: {reversedString2}");
    }
    public static void Task3()
    {
        Console.WriteLine("\nУпражнение 8.3\n");
        //Написать программу, которая спрашивает у пользователя имя файла. Если
        //такого файла не существует, то программа выдает пользователю сообщение и заканчивает
        //работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
        //буквами.

        string fileName = "text.txt";
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string[] files = Directory.GetFiles(baseDirectory, "*.txt");
        foreach (string file in files)
        {
            if (!File.Exists(Path.GetFileName(file)))
            {
                Console.WriteLine("Файл не существует.");
                return;
            }
        }
        
        try
        {
            string text = File.ReadAllText(fileName);
            string upperText = text.ToUpper();

            string newFileName = Path.GetFileNameWithoutExtension(fileName) + "_upper" + Path.GetExtension(fileName);
            File.WriteAllText(newFileName, upperText);

            Console.WriteLine("Содержимое файла записано в файл " + newFileName + " в верхнем регистре.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
    static bool CheckIfIFormattable(object obj)
    {
        if (obj is IFormattable)
        {
            return true;
        }
        IFormattable formattable = obj as IFormattable;
        return formattable != null;
    }
    public static void Task4()
    {
        Console.WriteLine("\nУпражнение 8.4\n");
        //Реализовать метод, который проверяет реализует ли входной параметр
        //метода интерфейс System.IFormattable.Использовать оператор is и as. (Интерфейс
        //IFormattable обеспечивает функциональные возможности форматирования значения объекта
        //в строковое представление.)

        object obj1 = 123;
        object obj2 = "Hello";
        object obj3 = 45.67; 
        Console.WriteLine(CheckIfIFormattable(obj1)); 
        Console.WriteLine(CheckIfIFormattable(obj2)); 
        Console.WriteLine(CheckIfIFormattable(obj3));
    }
    public static void SearchMail(ref string s)
    {
        string[] parts = s.Split('#');
        if (parts.Length > 1)
        {
            s = parts[1].Trim();
        }
        else
        {
            s = string.Empty;
        }
    }
    public static void Task5()
    {
        Console.WriteLine("Домашнее задание 8.1");
        //Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail
        //адрес.Разделителем между ФИО и адресом электронной почты является символ #:
        //Иванов Иван Иванович # iviviv@mail.ru
        //Петров Петр Петрович # petr@mail.ru
        //Сформировать новый файл, содержащий список адресов электронной почты.
        //Предусмотреть метод, выделяющий из строки адрес почты. Методу в
        //качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:

        string inputFilePath = "input.txt"; 
        string outputFilePath = "output.txt";

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Входной файл не найден.");
            return;
        }

        bool emailFound = false;
        foreach (var line in File.ReadLines(inputFilePath))
        {
            string email = line;
            SearchMail(ref email); 
            if (!string.IsNullOrEmpty(email))
            {
                emailFound = true; 
        
                using (StreamWriter writer = new StreamWriter(outputFilePath, true))
                {
                    writer.WriteLine(email);
                }
            }
        }

        if (emailFound)
        {
            Console.WriteLine("Адреса электронной почты успешно сохранены в файл " + outputFilePath);
        }
        else
        {
            Console.WriteLine("Адреса электронной почты не найдены.");
        }
    }
    public static void Task6()
    {
        Console.WriteLine("\nДомашнее задание 8.2\n");
        //Список песен. В методе Main создать список из четырех песен. В
        //цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую
        //песню в списке.Песня представляет собой класс с методами для заполнения каждого из
        //полей, методом вывода данных о песне на печать, методом, который сравнивает между
        //собой два объекта
        // Пример:
        // Селфхарм - Монеточка
        // Моя невеста - Егор Крид
        // В белом невесте - 4k
        // Tramp - Otis Redding
        // Заходи - Амбисаша
        try
        {
            List<Song> songs = new List<Song>();

            for (int i = 0; i < 4; i++)
            {
                Song song = new Song();
                string songName, songAuthor;

                Console.Write($"Введите название песни {i + 1}: ");
                songName = (Console.ReadLine());

                if (string.IsNullOrWhiteSpace(songName))
                {
                    throw new ArgumentNullException();
                }

                Console.Write($"Введите автора песни {i + 1}: ");
                songAuthor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(songAuthor))
                {
                    throw new ArgumentException();
                }

                song.SetName(songName);
                song.SetAuthor(songAuthor);

                if (i > 0)
                {
                    song.SetPrev(songs[i - 1]);
                }

                songs.Add(song);
            }

            Console.WriteLine("\nИнформация о песнях:");
            foreach (var song in songs)
            {
                song.Title();
            }

            if (songs.Count >= 2)
            {
                bool areEqual = songs[0].Equals(songs[1]);
                if (areEqual)
                {
                    Console.WriteLine("\nПервая и вторая песни одинаковые.");
                }
                else
                {
                    Console.WriteLine("\nПервая и вторая песни разные.");
                }
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Ошибка: Название песни не может быть пустым. Попробуйте снова");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Ошибка: Автор песни не может быть пустым. Попробуйте снова");
        }
    }
}
