using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassHW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stList = new List<Student> {
                new Student("Dzenan", "Ganovic", "email3368@auvih.edu.ba"),
                new Student("Amar", "Ikovic", "email1326@auvih.edu.ba"),
                new Student("Adnan", "Rahic", "email9879@auvih.edu.ba"),
            };

            stList.Sort();
            stList.ForEach(student => Console.WriteLine(student));

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
    }

    class Person
    {
        protected string name, lastName;

        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        protected string getPersonInfo()
        {
            return name + ", " + lastName;
        }
    }
    
    class Student : Person, IComparable<Student>
    {
        public string email {get; set;}
        private string Location;
        public string location
        {
            get
            {
                if (Location == "SA")
                {
                    return "Sarajevo";
                }
                else if (Location == "TZ")
                {
                    return "Tuzla";
                }
                else
                {
                    return "Other";
                }
            }
            set
            {
                if (value == "SA" || value == "SARAJEVO" || value == "Sarajevo")
                {
                    Location = "Sarajevo";
                }
                else if (value == "TZ" || value == "TUZLA" || value == "Tuzla")
                {
                    Location = "Tuzla";
                }
                else
                {
                    Location = "NA";
                }
            }
        }

        public Student() : base("Dzenan", "Ganovic")
        {
            this.email = "email@aubih.edu.ba";
            this.location = "Sarajevo";
        }

        ~Student() {

        }

        public Student(string name, string lastname, string email)
            : base(name, lastname)
        {
            this.email = email;
            this.location = "Sarajevo";
        }

        public bool setName(string input)
        {
            if (input.Length <= 2)
            {
                Console.WriteLine("Name must be at least two characters long");
                return false;
            }

            char[] cArray = input.ToCharArray();
            foreach(char c in cArray) {
                if(!char.IsLetter(c)) {
                    Console.WriteLine("Name can only have letters");
                return false;
                }
            }

            if (char.IsUpper(cArray[0]))
            {
                Console.WriteLine("Name must start with an uppercase letter");
                return false;
            }

            return true;
        }
        
        public string getStudentInfo()
        {
            return base.getPersonInfo() + ", " + this.email + ", " + this.location;
        }

        public override string ToString()
        {
            return getStudentInfo();
        }

        public int CompareTo(Student student)
        {
            return this.email.CompareTo(student.email);
        }
    }
}
