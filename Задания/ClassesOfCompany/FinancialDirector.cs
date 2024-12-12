using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class FinancialDirector : Employee
    {
        /// <summary>
        /// Конструктор для создания финансового директора
        /// </summary>
        /// <param name="name">Имя финансового директора</param>
        /// <param name="manager">Менеджер финансового директора</param>
        public FinancialDirector(string name, Employee manager) : base(name, "Финансовый директор", manager) { }

        public override bool CanTakeTask(string taskType)
        {
            return taskType == "начальству";
        }
    }
}
