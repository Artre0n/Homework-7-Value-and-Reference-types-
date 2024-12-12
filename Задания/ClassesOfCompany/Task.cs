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
            if (employee != null)
            {
                // Сотрудник может назначать задачи, если у него нет менеджера
                // Либо если он может взять задачу по типу
                if (employee.Manager == null || employee.CanTakeTask(TaskType))
                {
                    Assignee = employee;
                    string managerName = Assignee.Manager?.Name ?? "неизвестный"; // Используем безопасный доступ
                    Console.WriteLine($"От {managerName} дается задача \"{Title}\" {employee.Name}. Задача принята");
                }
                else
                {
                    string managerName = Assignee?.Manager?.Name ?? "неизвестный"; // Используем безопасный доступ
                    Console.WriteLine($"От {managerName} дается задача \"{Title}\" {employee.Name}. Задача не может быть принята");
                }
            }
            else
            {
                Console.WriteLine($"Задача \"{Title}\" не может быть назначена");
            }
        }
    }

}
