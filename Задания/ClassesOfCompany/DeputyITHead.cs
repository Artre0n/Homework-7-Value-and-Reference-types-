using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class DeputyManager : Employee
    {
        /// <summary>
        /// Конструктор для создания зам.начальника
        /// </summary>
        /// <param name="name">Имя зам.начальника</param>
        /// <param name="manager">Менеджер зам.начальника</param>
        public DeputyManager(string name, Employee manager) : base(name, "Зам.начальника", manager) { }

        public override bool CanTakeTask(string taskType)
        {
            return taskType == "начальству";
        }
    }
}
