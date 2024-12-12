using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class SystemAnalyst : Employee
    {
        /// <summary>
        /// Конструктор для создания системщика
        /// </summary>
        /// <param name="name">Имя системщика</param>
        /// <param name="manager">Менеджер системщика</param>
        public SystemAnalyst(string name, Employee manager) : base(name, "Системщик", manager) { }

        public override bool CanTakeTask(string taskType)
        {
            return taskType == "системщикам";
        }
    }
}
