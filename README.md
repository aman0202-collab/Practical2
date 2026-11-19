# Practical 2 - Employee Payroll System

**Aim:** Design Employee Payroll System using Inheritance, Interface & Polymorphism.

A Windows Forms application (.NET Framework 4.8) to add employees and calculate their net salary. Full Time employees get Basic + HRA (20%) + DA (10%); Part Time employees get Working Hours x Hourly Rate.

## OOP Concepts Used

- **Interface** - `IEmployee` fixes the contract: EmployeeID, EmployeeName and `CalculateSalary()`.
- **Inheritance** - `FullTimeEmployee` and `PartTimeEmployee` inherit the base class `Employee`.
- **Polymorphism** - `CalculateSalary()` is `virtual` in the base class and overridden in both child classes; all employees are stored in one `List<Employee>` and the correct formula runs automatically.

## Files

- `IEmployee.cs` - the interface
- `Employee.cs` - base class
- `FullTimeEmployee.cs` / `PartTimeEmployee.cs` - derived classes
- `Form1.cs` - the payroll form (interface is created in code)

## Steps to Run

1. Open `practical2/practical2.sln` in Visual Studio 2022.
2. Press **F5** to run the application.
