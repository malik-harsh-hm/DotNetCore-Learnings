
namespace ConsoleApp1
{
    public class Person
    {
        // Auto implemented property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }

        // Parameterized constructor
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}


