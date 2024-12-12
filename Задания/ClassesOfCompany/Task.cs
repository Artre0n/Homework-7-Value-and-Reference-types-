using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.ClassesOfCompany
{
    public class Task
    {
        /// <summary>
        /// Задача
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Тип задачи
        /// </summary>
        public string TaskType { get; private set; }

        /// <summary>
        /// Назначенный сотрудник
        /// </summary>
        public Employee Assignee { get; private set; }

        /// <summary>
        /// Конструктор для создания задачи
        /// </summary>
        /// <param name="title">Заголовок задачи</param>
        /// <param name="taskType">Тип задачи</param>
        public Task(string title, string taskType)
        {
            Title = title;
            TaskType = taskType;
        }

        /// <summary>
        /// Назначает задачу сотруднику
        /// </summary>
        /// <param name="employee">Сотрудник, которому назначается задача</param>
        public void AssignTask(Employee employee)
        {
            if (employee.CanTakeTask(TaskType))
            {
                Assignee = employee;
                if (Assignee.Manager != null)
                {
                    Console.WriteLine($"От {Assignee.Manager.Name} дается задача \"{Title}\" {employee.Name}. Задача принята.");
                }
                else
                {
                    Console.WriteLine($"От неизвестного дается задача \"{Title}\" {employee.Name}. Задача принята.");
                }
            }
            else
            {
                if (Assignee.Manager != null)
                {
                    Console.WriteLine($"От {Assignee.Manager.Name} дается задача \"{Title}\" {employee.Name}. Задача не может быть принята.");
                }
                else
                {
                    Console.WriteLine($"От неизвестного дается задача \"{Title}\" {employee.Name}. Задача не может быть принята.");
                }
            }
        }
    }

}
