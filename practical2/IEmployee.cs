namespace practical2
{
    // Interface - every employee type must follow this contract.
    // It fixes WHAT an employee can do, not HOW it is done.
    public interface IEmployee
    {
        string EmployeeID { get; }
        string EmployeeName { get; }

        // Every employee type must provide its own salary calculation
        decimal CalculateSalary();
    }
}
