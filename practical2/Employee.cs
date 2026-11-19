namespace practical2
{
    // Base class - common data of every employee.
    // FullTimeEmployee and PartTimeEmployee inherit from this class.
    public class Employee : IEmployee
    {
        // Private data members (access modifiers)
        private string employeeID;
        private string employeeName;
        private decimal basicSalary;

        // Constructor
        public Employee(string id, string name, decimal basicSalary)
        {
            employeeID = id;
            employeeName = name;
            this.basicSalary = basicSalary;
        }

        // Public properties
        public string EmployeeID
        {
            get { return employeeID; }
        }

        public string EmployeeName
        {
            get { return employeeName; }
        }

        public decimal BasicSalary
        {
            get { return basicSalary; }
        }

        // Virtual method - child classes override it with their
        // own salary formula (Polymorphism)
        public virtual decimal CalculateSalary()
        {
            return basicSalary;
        }
    }
}
