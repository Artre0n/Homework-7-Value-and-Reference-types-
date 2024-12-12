using Тумаков___Лабораторная_8_главы;
using Тумаков___Лабораторная_8_главы.Classes;
using System.IO;

public class Programm
{
    public static void Main()
    {
        //Task1();
        //Task2();
        Task3();
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

        Console.Write("Введите имя файла: ");
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
}