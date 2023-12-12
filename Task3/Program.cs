using System.Text.Json;
using System.Xml.Serialization;
using Task3;

//CreateFile(); использовал для создания json
Employee[] myEmployees = ReadFile();
bool isWorking = true;
while (isWorking)
{
    Console.WriteLine($"1.Найти сотрудника по имени{Environment.NewLine}" +
    $"2.Найти сотрудников пользующихся выбранным языком{Environment.NewLine}" +
    $"3.Сохранить данные в XML{Environment.NewLine}" +
    $"4.Выйти{Environment.NewLine}");
    string choise = Console.ReadLine();
    switch (choise)
    {
        case "1":
            Console.WriteLine("Введите имя сотрудника");
            string name = Console.ReadLine();
            GetEmployeeByName(name, myEmployees);
            break;
        case "2":
            Console.WriteLine("Введите язык программирования");
            string language = Console.ReadLine();
            GetEmployeesByLanguage(language, myEmployees);
            break;
        case "3":
            CreateXmlFile(myEmployees);
            break;
        case "4":
            isWorking = false;
            break;
        default:
            Console.WriteLine("Выбран несуществующий вариант");
            break;
    }
}

void GetEmployeesByLanguage(string languageToFind, Employee[] employees)
{
    try
    {
        foreach (Employee employee in employees)
        {
            foreach (string language in employee.Languages)
            {
                if (language.ToLower() == languageToFind.ToLower())
                {
                    Console.WriteLine(employee.Name);
                }
            }
        }
        Console.WriteLine(Environment.NewLine);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void GetEmployeeByName(string name, Employee[] employees)
{
    try
    {
        foreach (Employee employee in employees)
        {
            if (employee.Name.ToLower() == name.ToLower())
            {
                Console.WriteLine(employee.ToString());
                break;
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

void CreateXmlFile(Employee[] employees)
{
    try
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee[]));
        using (FileStream fileStream = new FileStream("myEmployees.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fileStream, employees);
            Console.WriteLine("Файл сохранён");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

void CreateFile()
{
    try
    {
        List<string> johnLanguages = new List<string>() { "C++", "Python" };
        List<string> alexLanguages = new List<string>() { "Pascal", "Delphi" };
        List<string> mariaLanguages = new List<string>() { "C#", "C++", "C" };
        Employee john = new Employee("John Smith", "02.10.1990", 175, 76.5, true, johnLanguages);
        Employee alex = new Employee("Alexey Alexeev", "05.06.1986", 197, 101.2, false, alexLanguages);
        Employee maria = new Employee("Maria Ivanova", "28.08.1998", 165, 56.1, true, mariaLanguages);
        Employee[] employees = new Employee[] { john, alex, maria };
        using (FileStream fileStream = new FileStream("emploees.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<Employee[]>(fileStream, employees);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

Employee[] ReadFile()
{
    try
    {
        using (FileStream fileStream = new FileStream("emploees.json", FileMode.OpenOrCreate))
        {
            Employee[]? employees = JsonSerializer.Deserialize<Employee[]>(fileStream);
            return employees;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return null;
    }
}