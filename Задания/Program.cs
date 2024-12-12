using Задания.ClassesOfCompany;
using Task = Задания.ClassesOfCompany.Task;

public class Program
{
    static void Main(string[] args)
    {
        // Создание иерархии сотрудников
        GeneralDirector timur = new GeneralDirector("Тимур");
        FinancialDirector rashid = new FinancialDirector("Рашид", timur);
        DirectorOfAutomation ilham = new DirectorOfAutomation("Ильхам", timur);
        Accountant lukas = new Accountant("Лукас", rashid);
        ITHead arkadiy = new ITHead("Аркадий", ilham);
        DeputyManager volodya = new DeputyManager("Володя", ilham);

        SystemAnalyst ilshat = new SystemAnalyst("Ильшат", arkadiy);
        Developer sergey = new Developer("Сергей", arkadiy);

       
        Task task1 = new Task("Обновление сети", "системщикам");
        Task task2 = new Task("Разработка нового интерфейса", "разработчикам");
        Task task3 = new Task("Настройка серверов", "системщикам");
        Task task5 = new Task("Обновление программного обеспечения", "системщикам");
        Task task6 = new Task("Создание базы данных", "разработчикам");
        Task task7 = new Task("Подготовка финансового отчета", "начальству");

        
         
        task1.AssignTask(ilshat); 
        task3.AssignTask(timur);   
        task2.AssignTask(sergey);  
        task5.AssignTask(rashid);  
        task3.AssignTask(ilshat);   
        task7.AssignTask(rashid);   
        task5.AssignTask(ilshat);    
        task6.AssignTask(sergey);    
        task7.AssignTask(timur);


        task1.AssignTask(sergey);
        task1.AssignTask(ilham); 
        task1.AssignTask(rashid); 
    }
}