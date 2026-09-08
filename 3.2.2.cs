using System;

public class Person
{
    public string Id { get; init; }

    public string FullName { get; set; }

    public int BirthYear { get; set; }

    public Person(
        string id,
        string fullName,
        int birthYear)
    {
        Id = id;
        FullName = fullName;
        BirthYear = birthYear;
    }

    public int GetAge(int currentYear)
    {
        return currentYear - BirthYear;
    }
}


public class Employee : Person
{
    public decimal BaseSalary { get; set; }

    public Employee(
        string id,
        string fullName,
        int birthYear,
        decimal baseSalary)
        : base(id, fullName, birthYear)
    {
        BaseSalary = baseSalary;
    }

    public virtual decimal CalculateIncome()
    {
        return BaseSalary;
    }
}


public sealed class Manager : Employee
{
    public decimal ResponsibilityAllowance { get; set; }

    public Manager(
        string id,
        string fullName,
        int birthYear,
        decimal baseSalary,
        decimal allowance)
        : base(
            id,
            fullName,
            birthYear,
            baseSalary)
    {
        ResponsibilityAllowance = allowance;
    }

    public override decimal CalculateIncome()
    {
        return BaseSalary + ResponsibilityAllowance;
    }
}


// manager la lop sealed nen khong the ke thua tiep


class Program
{
    static void Main()
    {
        string title = "bai tap 2";
        Console.WriteLine(title);

        Console.WriteLine("nhap nam hien tai");
        int currentYear =
            int.Parse(Console.ReadLine() ?? "0");


        Console.WriteLine("nhap ma nhan vien");
        string employeeId =
            Console.ReadLine() ?? "";

        Console.WriteLine("nhap ten nhan vien");
        string employeeName =
            Console.ReadLine() ?? "";

        Console.WriteLine("nhap nam sinh nhan vien");
        int employeeBirthYear =
            int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("nhap luong co ban nhan vien");
        decimal employeeSalary =
            decimal.Parse(Console.ReadLine() ?? "0");


        Employee employee =
            new Employee(
                employeeId,
                employeeName,
                employeeBirthYear,
                employeeSalary);


        Console.WriteLine("nhap ma quan ly");
        string managerId =
            Console.ReadLine() ?? "";

        Console.WriteLine("nhap ten quan ly");
        string managerName =
            Console.ReadLine() ?? "";

        Console.WriteLine("nhap nam sinh quan ly");
        int managerBirthYear =
            int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("nhap luong co ban quan ly");
        decimal managerSalary =
            decimal.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("nhap phu cap trach nhiem");
        decimal managerAllowance =
            decimal.Parse(Console.ReadLine() ?? "0");


        Manager manager =
            new Manager(
                managerId,
                managerName,
                managerBirthYear,
                managerSalary,
                managerAllowance);


        string employeeTitle =
            "phieu luong nhan vien";

        Console.WriteLine(employeeTitle);

        string employeeNameText =
            $"ten {employee.FullName}";

        Console.WriteLine(employeeNameText);

        int employeeAge =
            employee.GetAge(currentYear);

        string employeeAgeText =
            $"tuoi {employeeAge}";

        Console.WriteLine(employeeAgeText);

        decimal employeeBaseSalary =
            employee.BaseSalary;

        string employeeSalaryText =
            $"luong co ban {employeeBaseSalary:N0} vnd";

        Console.WriteLine(employeeSalaryText);

        decimal employeeIncome =
            employee.CalculateIncome();

        string employeeIncomeText =
            $"thu nhap {employeeIncome:N0} vnd";

        Console.WriteLine(employeeIncomeText);


        string managerTitle =
            "phieu luong quan ly";

        Console.WriteLine(managerTitle);

        string managerNameText =
            $"ten {manager.FullName}";

        Console.WriteLine(managerNameText);

        int managerAge =
            manager.GetAge(currentYear);

        string managerAgeText =
            $"tuoi {managerAge}";

        Console.WriteLine(managerAgeText);

        decimal managerBaseSalary =
            manager.BaseSalary;

        string managerSalaryText =
            $"luong co ban {managerBaseSalary:N0} vnd";

        Console.WriteLine(managerSalaryText);

        decimal managerIncome =
            manager.CalculateIncome();

        string managerIncomeText =
            $"thu nhap {managerIncome:N0} vnd";

        Console.WriteLine(managerIncomeText);
    }
}
