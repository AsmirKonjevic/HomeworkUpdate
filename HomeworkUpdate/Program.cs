using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmir_Konjevic_Homework
{
    class Person
    {

        protected string name, lastName;

        private static int _counter = 0;

        public static int counter
        {
            get
            {
                return _counter;
            }

            private set
            {
                _counter = value;
            }
        }

        public bool setLastName(string inpt, out string error)
        {
            if (inpt.Length < 2)
            {

                error = "Name must be at least two characters long";

                return false;

            }



            if (!inpt.All(Char.IsLetter))
            {

                error = "Name can only have letters";

                return false;

            }

            char[] chArray = inpt.ToCharArray();
            int count = 0;
            foreach (char c in chArray)
            {

                if (count == 0 && !char.IsUpper(c))
                {

                    error = "Name must start with an uppercase letter";
                    return false;

                }

                if (count != 0 && !char.IsLower(c))
                {
                    error = "All letter except first one must be lowercase!";
                    return false;
                }
                count++;
            }

            inpt = lastName;
            error = "";
            return true;
        }

        public static string LastName
        {
            set
            {

                if (value.Length < 2) throw new ArgumentException("Last Name has to be more than 2 characters long");

                if (!value.All(Char.IsLetter)) throw new ArgumentException("All characters must be letters");


                char[] chArray = value.ToCharArray();
                int count = 0;
                foreach (char c in chArray)
                {

                    if (count == 0 && !char.IsUpper(c)) throw new ArgumentException("First letter must be uppercase");


                    if (count != 0 && !char.IsLower(c)) throw new ArgumentException("All letters except first one must be lowercase");

                    count++;
                }

                LastName = value;

            }

            get
            {
                return LastName;
            }
        }

        public Person(string name, string lastName)
        {

            this.name = name;

            this.lastName = lastName;

            counter++;

        }

        public string getPersonInfo() { return name + ", " + lastName; }

    };

    class Student : Person, IComparable<Student>
    {

        private string email;
        private string location;

        public Student(string name, string lastName, string location, string email)
            : base(name, lastName)
        {

            this.location = location;
            this.email = email;
        }



        public bool setLocation(string inpt)
        {
            if (inpt == "Tuzla" || inpt == "Sarajevo")
            {
                return true;
            }
            if (inpt == "")
            {
                Console.WriteLine("Location can not be Empty!");
                return false;
            }
            Console.WriteLine("Invalid input , please try again! ");
            return false;

        }

        public bool setName(string input)
        {

            if (input.Length < 2)
            {

                Console.WriteLine("Name must be at least two characters long");

                return false;

            }



            if (!input.All(Char.IsLetter))
            {

                Console.WriteLine("Name can only have letters");

                return false;

            }

            char[] chArray = input.ToCharArray();
            int count = 0;
            foreach (char c in chArray)
            {

                if (count == 0 && !char.IsUpper(c))
                {

                    Console.WriteLine("Name must start with an uppercase letter");
                    return false;

                }

                if (count != 0 && !char.IsLower(c))
                {
                    Console.WriteLine("All letter except first one must be lowercase!");
                    return false;
                }
                count++;
            }

            input = base.name;
            return true;
        }

        public bool setEmail(string input, out string errorMsg)
        {
            // 1. String has to contain "@" character
            if (!input.Contains("@"))
            {
                errorMsg = "String has to contain '@' character";
                return false;
            }

            //2. String has to contain at least one "." after "@"character
            char[] arrayChar = input.ToCharArray();


            bool foundAtChar = false;
            //int dotCount = 0;
            bool foundDot = false;

            for (int i = 0; i < arrayChar.Length; i = i + 1)
            {
                if (arrayChar[i] == '@')
                {
                    foundAtChar = true;
                    continue;
                }

                if (foundAtChar)
                {
                    if (arrayChar[i] == '.')
                    {
                        foundDot = true;
                        break;
                    }

                }
            }

            if (!foundDot)
            {
                errorMsg = "String has to contain at least one '.' after '@'character";
                return false;
            }

            // 3. String has to have one of following (domains) including last dot ".com", ".ba" or ".edu"
            string endString = input.Substring(input.Length - 4);
            string endString3 = input.Substring(input.Length - 3);

            if (endString == ".com" || endString == ".edu" || endString3 == ".ba")
            {
                errorMsg = "String has to end '.com', '.ba' or '.edu'";
                return true;
            }

            else
            {
                errorMsg = "String has to end '.com', '.ba' or '.edu'";
                return false;
            }
            int indexAt;
            // 4. String has to have at least one character before "@"
            indexAt = input.IndexOf('@');
            if (indexAt == 0)
            {
                errorMsg = "String has to have at least one character before '@'";
                return false;
            }

            //5. In addition to @ and . string can only contain alpha numeric characters and underscore "_". 
            foreach (char c in arrayChar)
            {
                if (!char.IsLetterOrDigit(c) || c != '@' || c != '_' || c != '.')
                {
                    errorMsg = "In addition to @ and . string can only contain alpha numeric characters and underscore ";
                    return false;
                }
            }
            //if here input is Valid email
            errorMsg = "";
            return true;
        }

        public string getStudentInfo()
        {
            return "Student " + base.name + " " + base.lastName + " from " + location + " with email " + email;
        }

        public string Email { get; set; }

        public string Location
        {
            get
            {
                if (location == "SA")
                {
                    location = "Sarajevo";
                }

                else if (location == "TZ")
                {
                    location = "Tuzla";
                }
                return location;

            }
            set
            {
                if (location == "SA" || location == "SARAJEVO" || location == "Sarajevo" || location == "sarajevo")
                {
                    location = "SA";
                }

                else if (location == "TZ" || location == "TUZLA" || location == "Tuzla" || location == "tuzla")
                {
                    this.location = "TZ";
                }
            }

        }

        public Student() : base(string.Empty, string.Empty) { }


        ~Student()
        {

        }
        public override string ToString()
        {
            return getStudentInfo();
        }

        public int CompareTo(Student other)
        {
            return this.location.CompareTo(other.location);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Asmir Konjevic 1C Homework...");
            Console.WriteLine("");
            string option = "";
            Console.WriteLine("Loading Program\n");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Welcome\n");
            System.Threading.Thread.Sleep(2000);
            List<Student> students = new List<Student> { };

            while (!option.Contains("3"))
            {
                Console.WriteLine("Choose Option Below\n");
                Console.WriteLine("1. Create New Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Exit\n");
                Console.Write("Enter Number of Option: ");
                option = Console.ReadLine();

                string nme;
                string location;
                string lastName;
                string email;
                string errorMsg;

                if (option == "1")
                {
                    Console.WriteLine("");
                    Console.Write("Enter Student Name: ");
                    nme = Console.ReadLine();
                    Student student = new Student();

                    while (!student.setName(nme))
                    {
                        Console.Write("Enter Student Name: ");
                        nme = Console.ReadLine();
                    }

                    Console.Write("Enter Student Lastname: ");
                    lastName = Console.ReadLine();

                    while (!student.setLastName(lastName, out errorMsg))
                    {

                        Console.WriteLine(errorMsg);
                        Console.Write("Enter Lastname Again!: ");
                        lastName = Console.ReadLine();
                    }

                    Console.Write("Enter Student Location(Tuzla or Sarajevo): ");
                    location = Console.ReadLine();

                    while (!student.setLocation(location))
                    {
                        Console.Write("Enter Student Location(Tuzla or Sarajevo): ");
                        location = Console.ReadLine();
                    }

                    Console.Write("Enter Student Email: ");
                    email = Console.ReadLine();

                    while (!student.setEmail(email, out errorMsg))
                    {
                        Console.WriteLine(errorMsg);
                        Console.WriteLine("");
                        Console.Write("Enter Student Email: ");
                        email = Console.ReadLine();
                    }
                    System.Threading.Thread.Sleep(1000);

                    Console.WriteLine("");
                    Console.WriteLine("New Student is Created");
                    Console.WriteLine("");
                    System.Threading.Thread.Sleep(2000);

                    Student newStudent = new Student(nme, lastName, location, email);
                    students.Add(newStudent);
                }

                if (option == "2")
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("");
                    students.Sort();
                    students.ForEach(Student => Console.WriteLine(Student.getStudentInfo() + "\n"));
                    Console.WriteLine("");
                    Console.WriteLine("");
                    System.Threading.Thread.Sleep(2000);
                }

            }
        }
    }
}



