using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class ITHead : Employee
    {
        /// <summary>
        /// Конструктор для создания начальника инф. систем
        /// </summary>
        /// <param name="name">Имя начальника инф. систем</param>
        /// <param name="manager">Менеджер начальника инф. систем</param>
        public ITHead(string name, Employee manager) : base(name, "Начальник инф. систем", manager) { }

        public override bool CanTakeTask(string taskType)
        {
            return taskType == "начальству";
        }
    }

}
