namespace practical2
{
    // Derived class - a part time employee inherits Employee
    // but is paid for the hours worked, not a fixed basic salary.
    public class PartTimeEmployee : Employee
    {
        // Extra data members only for part time employees
        private int workingHours;
        private decimal hourlyRate;

        // Constructor
        public PartTimeEmployee(string id, string name,
                                int workingHours, decimal hourlyRate)
            : base(id, name, 0)
        {
            this.workingHours = workingHours;
            this.hourlyRate = hourlyRate;
        }

        public int WorkingHours
        {
            get { return workingHours; }
        }

        public decimal HourlyRate
        {
            get { return hourlyRate; }
        }

        // Override - salary = Working Hours x Hourly Rate
        public override decimal CalculateSalary()
        {
            return workingHours * hourlyRate;
        }
    }
}
