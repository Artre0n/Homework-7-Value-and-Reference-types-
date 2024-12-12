using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class Accountant : Employee
    {
        /// <summary>
        /// Конструктор для создания главного бухгалтера
        /// </summary>
        /// <param name="name">Имя главного бухгалтера</param>
        /// <param name="manager">Менеджер главного бухгалтера</param>
        public Accountant(string name, Employee manager) : base(name, "Главный бухгалтер", manager) { }

        public override bool CanTakeTask(string taskType)
        {
            return taskType == "начальству";
        }
    }

}
