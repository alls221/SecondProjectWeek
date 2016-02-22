using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BootCampReSourceCheckoutV2
{
    class Program
    {
        static void Title() // method to print the title
        {
            StringBuilder title = new StringBuilder();
            title.Append("WCCI ");
            title.Append("Bootcamp ");
            title.Append("Resources ");
            title.Append("Checkout ");
            title.Append("System.");
            Console.WriteLine(title + "\n\n\n");
        }
        static void Menu() //method to print the menu
        {
            List<string> menu = new List<string>() { "1-View Students", "2-View Avalable Resources", "3-View Student Accounts", "4-Checkout Item", "5-Return Item", "6-Checked Out Resources", "7-Exit" };
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(menu[i]);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Select ");
            sb.Append("a ");
            sb.Append("menu ");
            sb.Append("option ");
            sb.Append("by ");
            sb.Append("number.");
            Console.WriteLine(sb);
        }
        static void ReturnToMain() // clears the screen before returning to the main menu
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Press ");
            sb.Append("any ");
            sb.Append("key ");
            sb.Append("to ");
            sb.Append("return ");
            sb.Append("to ");
            sb.Append("the ");
            sb.Append("main ");
            sb.Append("menu.");


            Console.WriteLine("\n"+ sb);
            Console.ReadKey();
            Console.Clear();
        }

        static string filename(int id, Dictionary<int, string> students)
        {
            StringBuilder createFileName = new StringBuilder();
            string name;
            if (students.TryGetValue(id, out name))
            {
                createFileName.Append(name + ".txt");
            }
            return createFileName.ToString();
        }
        static void listStudents(Dictionary<int, string> students)
        {
            foreach (KeyValuePair<int, string> pair in students)
            {
                Console.WriteLine("Id: " + pair.Key + "   Student: " + pair.Value);
            }
        }
        static int Idgetter()
        {
            Dictionary<int, string> students = new Dictionary<int, string> { { 101, "Ashley Stewart" }, { 102, "Krista Scholdberg" }, { 103, "Imari Childress" }, { 104, "Lawrence Hudson" }, { 105, "Jacob Lockyer" } };
            int id;

            while (true)
            {
                Console.WriteLine("Enter the Id number of the student.");
                Console.WriteLine("If You dont know the id number, type \"List\" to view a list of students.");
                string Input = Console.ReadLine();

                if (Input.Equals("List", StringComparison.CurrentCultureIgnoreCase))
                {
                    listStudents(students);
                    Console.WriteLine("Press Any Key to continue");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    if (int.TryParse(Input, out id) == true)
                    {
                        return id;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Dictionary<int,string> students= new Dictionary<int, string> { { 101, "Ashley Stewart" }, { 102, "Krista Scholdberg" }, { 103, "Imari Childress" }, { 104, "Lawrence Hudson" }, { 105, "Jacob Lockyer" } };
            List<string> resources = new List<string> { "Visual C#", "Java for Kids", "C# Player's Guide", "Beginner's Guide to Visual Studio", "Programming for Dummies", "Intro to Java Script", "SQL Databases", "HTML and CSS", "Database Design for Mere Mortals", "ASP.Net MVC 5" }; //lists resources in system
            List <string> student101 = new List<string> {"Ashley Stewart" }; // each of these lists is one students account
            List<string> student102 = new List<string> { "Krista Scholdberg" };
            List<string> student103 = new List<string> { "Imari Childress" };
            List<string> student104 = new List<string> { "Lawrence Hudsan" };
            List<string> student105 = new List<string> { "Jacob Lockyer" };
            List<string> checkedOutResources = new List<string>{ };
            while (true)
            {
                Title();
                Menu();
                string choice = Console.ReadLine();
                int menuChoice;
                bool res = int.TryParse(choice, out menuChoice);

                if (res == false)
                {
                    Console.WriteLine("Enter your choice as an integer." + "\n\a");
                    ReturnToMain();
                }

                if (menuChoice == 7) // allows the user to exit the program breaking the while loop
                {
                    Console.WriteLine("Exiting");
                    break;
                }

                switch (menuChoice)
                {
                    case 1://view students section
                        Console.Clear();
                        Title();
                        var studentsAlpha = students.Values.ToList(); // this converts the keys of the student dictionary to a list so they can be alphabetized
                        studentsAlpha.Sort();
                        foreach (var value in studentsAlpha) // loops through the list of students (made from the keys of the dictionary and prints them too the console
                        {
                            Console.WriteLine(value);
                        }
                        ReturnToMain();
                        break;
                    case 2:// available resources section
                        Console.Clear();
                        Title();
                        resources.Sort();
                        for (int j = 0; j < resources.Count; j++)
                        {
                            Console.WriteLine(resources[j]);
                        }

                        if (resources.Count == 0)// this lets the user know no resourse available
                        {
                            Console.WriteLine("All resources are checked out." + "\n\a");
                        }
                        ReturnToMain();
                        break;
                    case 3: //this sections is for student accounts
                        Console.Clear();
                        Title();
                        int id = Idgetter();
                        switch (id) // this switch case uses the individual student lists to view their account
                        {
                            case 101:
                                Console.Clear();
                                Title();
                                for (int i = 0; i < student101.Count; i++)
                                {
                                    Console.WriteLine(student101[i]);
                                }
                                if (student101.Count==1)
                                {
                                    Console.WriteLine("No resources checked out");
                                }
                                break;
                            case 102:
                                Console.Clear();
                                Title();
                                for (int i = 0; i < student102.Count; i++)
                                {
                                    Console.WriteLine(student102[i]);
                                }
                                if (student102.Count == 1)
                                {
                                    Console.WriteLine("No resources checked out");
                                }
                                break;
                            case 103:
                                Console.Clear();
                                Title();
                                for (int i = 0; i < student103.Count; i++)
                                {
                                    Console.WriteLine(student103[i]);
                                }
                                if (student103.Count == 1)
                                {
                                    Console.WriteLine("No resources checked out");
                                }
                                break;
                            case 104:
                                Console.Clear();
                                Title();
                                for (int i = 0; i < student104.Count; i++)
                                {
                                    Console.WriteLine(student104[i]);
                                }
                                if (student104.Count == 1)
                                {
                                    Console.WriteLine("No resources checked out");
                                }
                                break;
                            case 105:
                                Console.Clear();
                                Title();
                                for (int i = 0; i < student105.Count; i++)
                                {
                                    Console.WriteLine(student105[i]);
                                }
                                if (student101.Count == 1)
                                {
                                    Console.WriteLine("No resources checked out");
                                }
                                break;
                        }
                        ReturnToMain();
                        break;
                    case 4: // check out resources
                        Console.Clear();
                        Title();
                        int studentnum = Idgetter();
                        StreamWriter sw = new StreamWriter(filename(studentnum, students));
                        using (sw)
                        {
                            switch (studentnum)
                            {
                                case 101:
                                    if (student101.Count == 4)
                                    {
                                        Console.WriteLine(student101[0] + " has checked out max number of resources");
                                        ReturnToMain();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a resource to check out");
                                        string resourceOut = Console.ReadLine();
                                        if (resources.Contains(resourceOut))
                                        {
                                            student101.Add(resourceOut);
                                            resources.Remove(resourceOut);
                                            checkedOutResources.Add(resourceOut);
                                            for (int i = 0; i < student101.Count; i++)
                                            {
                                                sw.WriteLine(student101[i]);
                                            }
                                            Console.WriteLine(student101[0] + " has checked out " + resourceOut);
                                            ReturnToMain();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Entry");
                                            ReturnToMain();
                                        }
                                    }
                                    break;
                                case 102:
                                    if (student102.Count == 4)
                                    {
                                        Console.WriteLine(student102[0] + " has checked out max number of resources");
                                        ReturnToMain();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a resource to check out");
                                        string resourceOut = Console.ReadLine();
                                        if (resources.Contains(resourceOut))
                                        {
                                            student102.Add(resourceOut);
                                            resources.Remove(resourceOut);
                                            checkedOutResources.Add(resourceOut);
                                            for (int i = 0; i < student102.Count; i++)
                                            {
                                                sw.WriteLine(student102[i]);
                                            }
                                            Console.WriteLine(student102[0] + " has checked out " + resourceOut);
                                            ReturnToMain();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Entry");
                                            ReturnToMain();
                                        }
                                    }
                                    break;
                                case 103:
                                    if (student103.Count == 4)
                                    {
                                        Console.WriteLine(student103[0] + " has checked out max number of resources");
                                        ReturnToMain();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a resource to check out");
                                        string resourceOut = Console.ReadLine();
                                        if (resources.Contains(resourceOut))
                                        {
                                            student103.Add(resourceOut);
                                            resources.Remove(resourceOut);
                                            checkedOutResources.Add(resourceOut);
                                            for (int i = 0; i < student103.Count; i++)
                                            {
                                                sw.WriteLine(student103[i]);
                                            }
                                            Console.WriteLine(student103[0] + " has checked out " + resourceOut);
                                            ReturnToMain();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Entry");
                                            ReturnToMain();
                                        }
                                    }
                                    break;
                                case 104:
                                    if (student104.Count == 4)
                                    {
                                        Console.WriteLine(student104[0] + " has checked out max number of resources");
                                        ReturnToMain();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a resource to check out");
                                        string resourceOut = Console.ReadLine();
                                        if (resources.Contains(resourceOut))
                                        {
                                            student104.Add(resourceOut);
                                            resources.Remove(resourceOut);
                                            checkedOutResources.Add(resourceOut);
                                            for (int i = 0; i < student104.Count; i++)
                                            {
                                                sw.WriteLine(student104[i]);
                                            }
                                            Console.WriteLine(student104[0] + " has checked out " + resourceOut);
                                            ReturnToMain();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Entry");
                                            ReturnToMain();
                                        }
                                    }
                                    break;
                                case 105:
                                    if (student105.Count == 4)
                                    {
                                        Console.WriteLine(student105[0] + " has checked out max number of resources");
                                        ReturnToMain();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a resource to check out");
                                        string resourceOut = Console.ReadLine();
                                        if (resources.Contains(resourceOut))
                                        {
                                            student105.Add(resourceOut);
                                            resources.Remove(resourceOut);
                                            checkedOutResources.Add(resourceOut);
                                            for (int i = 0; i < student105.Count; i++)
                                            {
                                                sw.WriteLine(student105[i]);
                                            }
                                            Console.WriteLine(student105[0] + " has checked out " + resourceOut);
                                            ReturnToMain();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Entry");
                                            ReturnToMain();
                                        }
                                    }
                                    break;
                            }
                            break;
                        }
                        case 5: // return an item
                        Console.Clear();
                        while (true)
                        {
                            Title();
                             int returnInput = Idgetter();
                            StreamWriter writer = new StreamWriter(filename(returnInput, students));
                            using (writer)
                            { 
                                if (returnInput == 101)
                                {
                                    Console.WriteLine(student101[0]);
                                    if (student101.Count > 1)
                                    {
                                        Console.WriteLine("Has checked out: ");
                                        for (int i = 1; i < student101.Count; i++)
                                        {
                                            Console.WriteLine(student101[i]);
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("What resource do you want to return");
                                            string returnItem = Console.ReadLine();
                                            if (student101.Contains(returnItem) == true)
                                            {
                                                student101.Remove(returnItem);
                                                checkedOutResources.Remove(returnItem);
                                                resources.Add(returnItem);
                                                Console.WriteLine(returnItem + " has been returned");
                                                for (int i = 0; i < student101.Count; i++)
                                                {
                                                    writer.WriteLine(student101[i]);
                                                }
                                                ReturnToMain();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again");
                                                continue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No resources out");
                                        ReturnToMain();
                                    }
                                }
                                if (returnInput == 102)
                                {
                                    Console.WriteLine(student102[0]);
                                    if (student102.Count > 1)
                                    {
                                        Console.WriteLine("Has checked out: ");
                                        for (int i = 1; i < student102.Count; i++)
                                        {
                                            Console.WriteLine(student102[i]);
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("What resource do you want to return");
                                            string returnItem = Console.ReadLine();
                                            if (student102.Contains(returnItem) == true)
                                            {
                                                student102.Remove(returnItem);
                                                checkedOutResources.Remove(returnItem);
                                                resources.Add(returnItem);
                                                Console.WriteLine(returnItem + " has been returned");
                                                for (int i = 0; i < student102.Count; i++)
                                                {
                                                    writer.WriteLine(student102[i]);
                                                }
                                                ReturnToMain();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again");
                                                continue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No resources out");
                                        ReturnToMain();
                                    }
                                }
                                if (returnInput == 103)
                                {
                                    Console.WriteLine(student103[0]);
                                    if (student103.Count > 1)
                                    {
                                        Console.WriteLine("Has checked out: ");
                                        for (int i = 1; i < student103.Count; i++)
                                        {
                                            Console.WriteLine(student103[i]);
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("What resource do you want to return");
                                            string returnItem = Console.ReadLine();
                                            if (student103.Contains(returnItem) == true)
                                            {
                                                student103.Remove(returnItem);
                                                checkedOutResources.Remove(returnItem);
                                                resources.Add(returnItem);
                                                Console.WriteLine(returnItem + " has been returned");
                                                for (int i = 0; i < student103.Count; i++)
                                                {
                                                    writer.WriteLine(student103[i]);
                                                }
                                                ReturnToMain();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again");
                                                continue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No resources out");
                                        ReturnToMain();
                                    }
                                }
                                if (returnInput == 104)
                                {
                                    Console.WriteLine(student104[0]);
                                    if (student104.Count > 1)
                                    {
                                        Console.WriteLine("Has checked out: ");
                                        for (int i = 1; i < student104.Count; i++)
                                        {
                                            Console.WriteLine(student104[i]);
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("What resource do you want to return");
                                            string returnItem = Console.ReadLine();
                                            if (student104.Contains(returnItem) == true)
                                            {
                                                student104.Remove(returnItem);
                                                checkedOutResources.Remove(returnItem);
                                                resources.Add(returnItem);
                                                Console.WriteLine(returnItem + " has been returned");
                                                for (int i = 0; i < student104.Count; i++)
                                                {
                                                    writer.WriteLine(student104[i]);
                                                }
                                                ReturnToMain();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again");
                                                continue;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("No resources out");
                                        ReturnToMain();
                                    }
                                }
                                if (returnInput == 105)
                                {
                                    Console.WriteLine(student105[0]);
                                    if (student105.Count > 1)
                                    {
                                        Console.WriteLine("Has checked out: ");
                                        for (int i = 1; i < student105.Count; i++)
                                        {
                                            Console.WriteLine(student105[i]);
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("What resource do you want to return");
                                            string returnItem = Console.ReadLine();
                                            if (student105.Contains(returnItem) == true)
                                            {
                                                student105.Remove(returnItem);
                                                checkedOutResources.Remove(returnItem);
                                                resources.Add(returnItem);
                                                Console.WriteLine(returnItem + " has been returned");
                                                for (int i = 0; i < student105.Count; i++)
                                                {
                                                    writer.WriteLine(student105[i]);
                                                }
                                                ReturnToMain();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again");
                                                continue;
                                            }
                                        }
                                        }
                                    else
                                    {
                                        Console.WriteLine("No resources out");
                                        ReturnToMain();
                                    }
                                }
                                }
                            
                            break;
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Title();
                        StreamWriter fileOut = new StreamWriter("checkedout.txt");
                        using (fileOut)
                        {
                            if (checkedOutResources.Count==0)
                            {
                                fileOut.Write("Nothing is currently checked out");
                            }
                            else
                            {
                                for (int i = 0; i < checkedOutResources.Count; i++)
                                {
                                    fileOut.Write(checkedOutResources[i]);
                                }
                            }
                        }
                        StreamReader sr = new StreamReader("checkedout.txt");
                        using (sr)
                        {
                            int lineNumber = 0;
                            string line = sr.ReadLine();
                            while(line!=null)
                            {
                                lineNumber++;
                                Console.WriteLine(line);
                                line = sr.ReadLine();
                            }
                            ReturnToMain();
                        }
                            break;
                }
            }
        }
    }
}
