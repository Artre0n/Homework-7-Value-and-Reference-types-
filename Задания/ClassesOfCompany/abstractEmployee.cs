using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public abstract class Employee
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Position { get; private set; }

        /// <summary>
        /// Менеджер сотрудника
        /// </summary>
        public Employee Manager { get; private set; }

        /// <summary>
        /// Список подчиненных сотрудников
        /// </summary>
        public List<Employee> Subordinates { get; private set; }

        /// <summary>
        /// Конструктор для создания нового сотрудника
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        /// <param name="manager">Менеджер сотрудника</param>
        protected Employee(string name, string position, Employee manager = null)
        {
            Name = name;
            Position = position;
            Manager = manager;
            Subordinates = new List<Employee>();
            if (manager != null)
            {
                if (manager.Subordinates == null)
                {
                    manager.Subordinates = new List<Employee>(); 
                }
                manager.Subordinates.Add(this); 
            }
            else
            {
                
            }
        }

        /// <summary>
        /// Определяет, может ли сотрудник взять задачу определенного типа
        /// </summary>
        /// <param name="taskType">Тип задачи</param>
        /// <returns>true, если сотрудник может взять задачу; иначе false</returns>
        public abstract bool CanTakeTask(string taskType);
    }
}
