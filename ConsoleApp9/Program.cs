namespace ConsoleApp9
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            PrintWeekDays();
            DisplayPersonDetails();
            DisplaySeasonMonthRange();
            ManagePermissions();
            CheckPrimaryColor();
            CalculateDistanceBetweenPoints();
            FindOldestPerson();
        }

        #region WeekDays Enum and Printing Days of the Week

        enum WeekDays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static void PrintWeekDays()
        {
            Console.WriteLine("Days of the Week:");
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }
            Console.WriteLine();
        }

        #endregion

        #region Person Struct and Displaying Person Details

        struct Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void DisplayPersonDetails()
        {
            Person[] people = new Person[3];

            people[0] = new Person { Name = "Alice", Age = 25 };
            people[1] = new Person { Name = "Bob", Age = 30 };
            people[2] = new Person { Name = "Charlie", Age = 35 };

            Console.WriteLine("Person Details:");
            foreach (Person person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
            Console.WriteLine();
        }

        #endregion

        #region Season Enum and Displaying Month Range for a Season

        enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        static void DisplaySeasonMonthRange()
        {
            Console.WriteLine("Enter a season (Spring, Summer, Autumn, Winter):");
            string input = Console.ReadLine();
            Season season;

            if (Enum.TryParse(input, true, out season))
            {
                switch (season)
                {
                    case Season.Spring:
                        Console.WriteLine("March to May");
                        break;
                    case Season.Summer:
                        Console.WriteLine("June to August");
                        break;
                    case Season.Autumn:
                        Console.WriteLine("September to November");
                        break;
                    case Season.Winter:
                        Console.WriteLine("December to February");
                        break;
                    default:
                        Console.WriteLine("Invalid season");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid season");
            }
            Console.WriteLine();
        }

        #endregion

        #region Permissions Enum and Managing Permissions

        [Flags]
        enum Permissions
        {
            None = 0,
            Read = 1,
            Write = 2,
            Delete = 4,
            Execute = 8
        }

        static void ManagePermissions()
        {
            Permissions userPermissions = Permissions.None;

            // Adding permissions
            userPermissions |= Permissions.Read;
            userPermissions |= Permissions.Write;

            // Checking permissions
            Console.WriteLine("Permissions:");
            Console.WriteLine($"Read: {userPermissions.HasFlag(Permissions.Read)}"); // True
            Console.WriteLine($"Delete: {userPermissions.HasFlag(Permissions.Delete)}"); // False

            // Removing a permission
            userPermissions &= ~Permissions.Write;

            // Checking permissions again
            Console.WriteLine($"Write: {userPermissions.HasFlag(Permissions.Write)}"); // False
            Console.WriteLine();
        }

        #endregion

        #region Colors Enum and Checking Primary Colors

        enum Colors
        {
            Red,
            Green,
            Blue,
            Yellow,
            Orange,
            Purple
        }

        static void CheckPrimaryColor()
        {
            Console.WriteLine("Enter a color name:");
            string input = Console.ReadLine();
            Colors color;

            if (Enum.TryParse(input, true, out color))
            {
                switch (color)
                {
                    case Colors.Red:
                    case Colors.Green:
                    case Colors.Blue:
                        Console.WriteLine($"{color} is a primary color.");
                        break;
                    default:
                        Console.WriteLine($"{color} is not a primary color.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid color");
            }
            Console.WriteLine();
        }

        #endregion

        #region Point Struct and Calculating Distance Between Two Points

        struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public double DistanceTo(Point other)
            {
                double dx = other.X - this.X;
                double dy = other.Y - this.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }
        }

        static void CalculateDistanceBetweenPoints()
        {
            Point point1 = new Point();
            Point point2 = new Point();

            Console.WriteLine("Enter coordinates for Point 1 (X Y):");
            var input1 = Console.ReadLine().Split();
            point1.X = double.Parse(input1[0]);
            point1.Y = double.Parse(input1[1]);

            Console.WriteLine("Enter coordinates for Point 2 (X Y):");
            var input2 = Console.ReadLine().Split();
            point2.X = double.Parse(input2[0]);
            point2.Y = double.Parse(input2[1]);

            double distance = point1.DistanceTo(point2);
            Console.WriteLine($"The distance between the two points is: {distance}");
            Console.WriteLine();
        }

        #endregion

        #region Person Struct and Finding Oldest Person

        static void FindOldestPerson()
        {
            Person[] people = new Person[3];

            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"Enter details for Person {i + 1} (Name Age):");
                var input = Console.ReadLine().Split();
                people[i] = new Person { Name = input[0], Age = int.Parse(input[1]) };
            }

            Person oldestPerson = people[0];

            foreach (Person person in people)
            {
                if (person.Age > oldestPerson.Age)
                {
                    oldestPerson = person;
                }
            }

            Console.WriteLine($"The oldest person is {oldestPerson.Name} with {oldestPerson.Age} years.");
        }

        #endregion
    }

}
