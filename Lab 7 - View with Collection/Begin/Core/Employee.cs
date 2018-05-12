namespace Core
{
    public class Employee
    {
        public Employee()
        {
        }
        public Employee(string firstName,
            string lastName, int salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}


