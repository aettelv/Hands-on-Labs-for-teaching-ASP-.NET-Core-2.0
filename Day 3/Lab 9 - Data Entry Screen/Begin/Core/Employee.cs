namespace Core
{
    public class Employee
    {
        public Employee()
        {
        }
        public Employee(string firstName,
            string lastName = null, int salary = 0)
        {
            FirstName = firstName?? string.Empty;
            LastName = lastName?? string.Empty;
            Salary = salary;
        }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}


