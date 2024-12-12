using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class Developer : Employee
    {
        /// <summary>
        /// Конструктор для создания разработчика
        /// </summary>
        /// <param name="name">Имя разработчика</param>
        /// <param name="manager">Менеджер разработчика</param>
        public Developer(string name, Employee manager) : base(name, "Разработчик", manager) { }

        public override bool CanTakeTask(string taskType)
        {
            return taskType == "разработчикам";
        }
    }
}
