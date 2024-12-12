using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тумаков___Лабораторная_8_главы.Classes
{
    public class BankAccount
    {
        /// <summary>
        /// Статическая переменная для генерации уникального номера счета
        /// </summary>
        private static int lastAccountNumber = 1;

        /// <summary>
        /// Закрытые поля
        /// </summary>
        private int accountNumber;
        private decimal balance;
        private AccountType accountType;

        /// <summary>
        /// Номер счета
        /// </summary>
        public int AccountNumber { get { return accountNumber; } }

        /// <summary>
        /// Баланс счета
        /// </summary>
        public decimal Balance { get { return balance; } }

        /// <summary>
        /// Тип банковского счета
        /// </summary>
        public AccountType AccountType { get { return accountType; } }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="accountType">Тип банковского счета</param>
        /// <param name="initialBalance">Начальный баланс</param>
        public BankAccount(AccountType accountType, decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Начальный баланс не может быть отрицательным\n");
            }

            this.accountNumber = lastAccountNumber++;
            this.accountType = accountType;
            this.balance = initialBalance;
        }

        /// <summary>
        /// Метод для вывода информации о счёте
        /// </summary>
        public void ShowAccountInfo()
        {
            Console.WriteLine("Информация о счёте:\n");
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Тип счета: {accountType}");
            Console.WriteLine($"Баланс: {balance}\n");
        }

        /// <summary>
        /// Метод для снятия со счета
        /// </summary>
        /// <param name="amount">Сумма для снятия</param>
        /// <returns>Возвращает true, если операция выполнена успешно, иначе false</returns>
        public bool Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Сумма для снятия не может быть отрицательной\n");
                return false;
            }

            if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств на счете\n");
                return false;
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Снято {amount}. Новый баланс: {balance}\n");
                return true;
            }
        }

        /// <summary>
        /// Метод для пополнения счета
        /// </summary>
        /// <param name="amount">Сумма для пополнения</param>
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Сумма для пополнения не может быть отрицательной\n");
                return;
            }

            balance += amount;
            Console.WriteLine($"Положено {amount}. Новый баланс: {balance}\n");
        }

        /// <summary>
        /// Метод для перевода денег с одного счета на другой
        /// </summary>
        /// <param name="paymentAccount">Счёт, с которого переводятся деньги</param>
        /// <param name="destinationAccount">Счет, на который переводятся деньги</param>
        /// <param name="amount">Сумма для перевода</param>
        /// <returns>Возвращает true, если операция выполнена успешно, иначе false</returns>
        public bool Transfer(BankAccount paymentAccount, BankAccount destinationAccount, decimal amount)
        {
            if (destinationAccount == null && destinationAccount is not BankAccount)
            {
                Console.WriteLine("Указан недействительный счет назначения\n");
                return false;
            }

            if (amount < 0)
            {
                Console.WriteLine("Сумма для перевода не может быть отрицательной\n");
                return false;
            }

            Console.WriteLine($"Перевод c счёта {paymentAccount.AccountNumber} на счёт {destinationAccount.AccountNumber}:");
            if (paymentAccount.Withdraw(amount))
            {
                destinationAccount.Deposit(amount);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
