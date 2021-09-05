using System;
using System.Collections.Generic;
using System.Globalization;
using d01_ex01;

var tasks = new List<Task>();

void TaskCreate()
{
    Task newTask = new Task();
    string title ;
    string summary;
    string dueDate;
    DateTime dueDateFromString;
    var cultureInfo = new CultureInfo("en-US");
    string type;
    TaskType typeFromString = 0;
    string priority;
    TaskPriority priorityFromString = 0;
    
    
     // required
    Console.WriteLine("Введите заголовок");
    while ((title = Console.ReadLine()) == "")
    {
        Console.WriteLine("Заголовок является обязательным");
        Console.WriteLine("Введите заголовок");
    }
    Console.WriteLine("Введите описание"); // not required
    summary = Console.ReadLine();
    if (summary == "" || summary == "-")
    {
        summary = null;
    }
    Console.WriteLine("Введите срок в формате mm/dd/yyyy"); // not required
    dueDate = Console.ReadLine();
    // Можно добавить проверку вводимой даты на корректность
    if (dueDate != "" && dueDate != "-" && dueDate != null)
    {
        dueDateFromString = DateTime.Parse(dueDate, cultureInfo);
    }
    else
    {
        dueDateFromString = DateTime.MinValue;
    }
    Console.WriteLine("Введите тип: work, study, personal"); // required
    while ((type = Console.ReadLine()) == "" || type != "work" && type != "study" && type != "personal")
    {
        Console.WriteLine("Тип является обязательным / Вы ввели некоректный тип или не ввели его совсем");
        Console.WriteLine("Введите тип: work, study, personal");
    }
    switch (type)
    {
        case "work":
            typeFromString = TaskType.Work;
            break;
        case "study":
            typeFromString = TaskType.Study;
            break;
        case "personal":
            typeFromString = TaskType.Personal;
            break;
        default:
            Console.WriteLine("Тип, который вы ввели, не поддерживается");
            break;
    }
    Console.WriteLine("Установите приоритет: low, normal, high"); // not required
    while ((priority = Console.ReadLine()) != "" && priority != "-" &&
           priority  != "low" && priority != "normal" && priority != "high")
    {
        Console.WriteLine("Вы ввели некоректный приоритет");
        Console.WriteLine("Установите приоритет: low, normal, high");
    }
    switch (priority)
    {
        case "low":
            priorityFromString = TaskPriority.Low;
            break;
        case "normal":
            priorityFromString = TaskPriority.Normal;
            break;
        case "high":
            priorityFromString = TaskPriority.High;
            break;
        case "":
            priorityFromString = TaskPriority.Normal;
            break;
        case "-":
            priorityFromString = TaskPriority.Normal;
            break;
        default:
            Console.WriteLine("Приоритет, который вы ввели, не поддерживается");
            break;
    }
    newTask.CreateNewTask(title, summary, dueDateFromString, typeFromString, priorityFromString);
    Console.WriteLine($"\n{newTask.ToString()}\n");
    tasks.Add(newTask);
}

void TaskDisplay()
{
    foreach (var task in tasks)
    {
        Console.WriteLine($"{task.ToString()}\n");
    }
}

void TaskDone()
{
    string title;
    int index = -1;
    int count = 0;
    
    Console.WriteLine("Введите заголовок");
    title = Console.ReadLine();
    foreach (var task in tasks)
    {
        if (task.Title == title)
        {
            index = count;
        }
        count++;
    }

    if (index == -1)
    {
        Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
    }
    else
    {
        if (tasks[index].TaskDone() != 0)
        {
            Console.WriteLine($"Задача [{tasks[index].Title}] выполнена!");
        }
    }
}

void TaskWontDo()
{
    string title;
    int index = -1;
    int count = 0;
    
    Console.WriteLine("Введите заголовок");
    title = Console.ReadLine();
    foreach (var task in tasks)
    {
        if (task.Title == title)
        {
            index = count;
        }
        count++;
    }

    if (index == -1)
    {
        Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
    }
    else
    {
        if (tasks[index].TaskWontDo() != 0)
        {
            Console.WriteLine($"Задача [{tasks[index].Title}] более не актуальна!");
        }
    }    
}

while (true)
{
    string command = Console.ReadLine();
    switch (command)
    {
        case "add":
            TaskCreate();
            break;
        case "list":
            TaskDisplay();
            break;
        case "done":
            TaskDone();
            break;
        case "wontdo":
            TaskWontDo();
            break;
        case "q":
            return;
        case "quit":
            return;
        default:
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            break;
    }
}





