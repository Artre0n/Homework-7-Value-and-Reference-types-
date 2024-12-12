using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class GeneralDirector : Employee
    {
        /// <summary>
        /// Конструктор для создания генерального директора
        /// </summary>
        /// <param name="name">Имя генерального директора</param>
        public GeneralDirector(string name) : base(name, "Генеральный директор") { }

        public override bool CanTakeTask(string taskType)
        {
            return false;
        }
    }
}
