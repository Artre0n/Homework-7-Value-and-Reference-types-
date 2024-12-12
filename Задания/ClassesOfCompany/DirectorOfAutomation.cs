using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class DirectorOfAutomation : Employee
    {
        /// <summary>
        /// Конструктор для создания директора по автоматизации
        /// </summary>
        /// <param name="name">Имя директора по автоматизации</param>
        /// <param name="manager">Менеджер директора по автоматизации</param>
        public DirectorOfAutomation(string name, Employee manager) : base(name, "Директор по автоматизации", manager) { }

        public override bool CanTakeTask(string taskType)
        {
            return taskType == "начальству";
        }
    }
}
