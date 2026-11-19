namespace practical2
{
    // Derived class - a full time employee inherits Employee
    // and gets HRA (20% of basic) and DA (10% of basic) extra.
    public class FullTimeEmployee : Employee
    {
        // Constructor passes common data to the base class
        public FullTimeEmployee(string id, string name, decimal basicSalary)
            : base(id, name, basicSalary)
        {
        }

        // Override - salary = Basic + HRA + DA
        public override decimal CalculateSalary()
        {
            decimal hra = BasicSalary * 0.20m;
            decimal da = BasicSalary * 0.10m;

            return BasicSalary + hra + da;
        }
    }
}
