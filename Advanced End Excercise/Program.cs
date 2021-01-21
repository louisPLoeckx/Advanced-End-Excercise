using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_End_Excercise.Models;

namespace Advanced_End_Excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lists
            //List<Lid> _Members = new List<Lid>();//?
            List<Bezoeker> _visitors = new List<Bezoeker>();
            List<Lid> _Member = new List<Lid>();
            List<Medewerker> _Employee = new List<Medewerker>();

          

            Bezoeker Visitor = null;
            Lid Member = null;
            Medewerker Employee = null;

            #region Creating single Lid, employee and visitor
            Bezoeker Frank = new Bezoeker("James", "Franko");
            Lid Joe = new Lid("joe", "Franko");
            Medewerker Louis = new Medewerker("Louis", "Loeckx");
            _visitors.Add(Frank);
            _Member.Add(Joe);
            _Employee.Add(Louis);
            #endregion

            string firstname = "";
            string lastname = "";

            #region Login Menu
            Console.WriteLine("Please log in as Lid or member");
            Console.WriteLine("Or as Visitor");
            Console.Write("[M] Member [E] employee [V] Visitor: ");
            ConsoleKey inputKey = Console.ReadKey().Key;
            Console.WriteLine();

            switch (inputKey)
            {
                case ConsoleKey.M:
                    Console.WriteLine("Please Login as Member:");
                    Console.Write("Firstname: ");
                    firstname = Console.ReadLine();
                    Console.Write("Lastname: ");
                    lastname = Console.ReadLine();

                    Member = new Lid(firstname, lastname);

                    #region ItemsInLibrary
                    Member._LibraryCollection.Add(new Item("Boek", 1, "To Kill A Mockingbird", "Harper Lee", 1960, false, false));
                    Member._LibraryCollection.Add(new Item("Boek", 2, "Catcher in the rye", "J.D. Salinger", 1951, false, false));
                    Member._LibraryCollection.Add(new Item("Boek", 3, "Nineteen Eighty Four", "George Orwel", 1949, false, false));
                    Member._LibraryCollection.Add(new Item("Boek", 4, "The Handmaids Tale", "Margaret Atwood", 1985, false, false));
                    Member._LibraryCollection.Add(new Item("DVD", 5, "Lord of the rings: The fellowship of the ring", "Peter jackson", 2001, false, false));
                    Member._LibraryCollection.Add(new Item("DVD", 6, "Metropolis", "Fritz Lang", 1927, false, false));
                    #endregion

                    if (_Member.Contains(Member))
                    {
                        Console.WriteLine("You have been logged in.");
                    }
                    else
                    {
                        Console.WriteLine("Member does not exist");
                        break;
                    }
                    Console.WriteLine();
                    Member.GeefOverzichtMembers(_Member);
                    break;
                case ConsoleKey.E:
                    Console.WriteLine("Please Login as Employee:");
                    Console.Write("Firstname: ");
                    firstname = Console.ReadLine();
                    Console.Write("Lastname: ");
                    lastname = Console.ReadLine();

                    // to move
                    
                    Employee = new Medewerker(firstname, lastname);

                    #region ItemsInLibrary
                    Employee._LibraryCollection.Add(new Item("Boek", 1, "To Kill A Mockingbird", "Harper Lee", 1960, false, false));
                    Employee._LibraryCollection.Add(new Item("Boek", 2, "Catcher in the rye", "J.D. Salinger", 1951, false, false));
                    Employee._LibraryCollection.Add(new Item("Boek", 3, "Nineteen Eighty Four", "George Orwel", 1949, false, false));
                    Employee._LibraryCollection.Add(new Item("Boek", 4, "The Handmaids Tale", "Margaret Atwood", 1985, false, false));
                    Employee._LibraryCollection.Add(new Item("DVD", 5, "Lord of the rings: The fellowship of the ring", "Peter jackson", 2001, false, false));
                    Employee._LibraryCollection.Add(new Item("DVD", 6, "Metropolis", "Fritz Lang", 1927, false, false));
                    #endregion

                    if (_Employee.Contains(Employee))
                    {
                        Console.WriteLine("You have been logged in.");
                    }
                    else
                    {
                        Console.WriteLine("Employee does not exist");
                        break;
                    }
                    Console.WriteLine();
                    Employee.GeefOverzichtEmployees(_Employee); ;
                    break;
                case ConsoleKey.V:
                    Console.WriteLine("Please Register as a visitor and enter a first and lastname");
                    Console.Write("Firstname: ");
                    firstname = Console.ReadLine();
                    Console.Write("Lastname: ");
                    lastname = Console.ReadLine();


                    Visitor = new Bezoeker(firstname, lastname);

                    #region ItemsInLibrary
                    Visitor._LibraryCollection.Add(new Item("Boek", 1, "To Kill A Mockingbird", "Harper Lee", 1960, false, false));
                    Visitor._LibraryCollection.Add(new Item("Boek", 2, "Catcher in the rye", "J.D. Salinger", 1951, false, false));
                    Visitor._LibraryCollection.Add(new Item("Boek", 3, "Nineteen Eighty Four", "George Orwel", 1949, false, false));
                    Visitor._LibraryCollection.Add(new Item("Boek", 4, "The Handmaids Tale", "Margaret Atwood", 1985, false, false));
                    Visitor._LibraryCollection.Add(new Item("DVD", 5, "Lord of the rings: The fellowship of the ring", "Peter jackson", 2001, false, false));
                    Visitor._LibraryCollection.Add(new Item("DVD", 6, "Metropolis", "Fritz Lang", 1927, false, false));
                    #endregion

                    if (_visitors.Contains(Visitor))
                    {
                        Console.WriteLine("You have been logged in.");
                        Console.WriteLine();
                        Visitor.GeefOverzichtVisitors(_visitors);
                    }
                    else
                    {
                        Console.WriteLine("You have been Logged in.");
                        _visitors.Add(Visitor);

                        Console.WriteLine();
                        Visitor.GeefOverzichtVisitors(_visitors);
                        break;
                    }
                    Console.WriteLine();
                    
                    break;
                default:
                    break;
            }

            #endregion

            #region Menu Visitor
            if (inputKey == ConsoleKey.V)
            {
                Console.WriteLine();
                Console.WriteLine("[R] Register for membership [S] Search for a specific item by id [O] Show items");
                ConsoleKey VisitorInputKey = Console.ReadKey().Key;
                Console.WriteLine();

                switch (VisitorInputKey)
                {
                    case ConsoleKey.O:
                        Visitor.ToonOverzicht(_visitors);
                        break;
                    case ConsoleKey.R:
                        Member = new Lid(firstname, lastname);
                        _Member.Add(Member);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.S:
                        Console.Write("What item do you wish to search for please enter an id: ");
                        int id = int.Parse(Console.ReadLine());
                        Visitor.ZoekItemMetId(id);
                        break;
                    default:
                        break;
                }
            }
            #endregion

            #region Menu Member
            if (inputKey == ConsoleKey.M)
            {
                Console.WriteLine();
                Console.WriteLine("[S] Search for a specific item by id or title [O] Show items [B] Borrow an item [R] return an item [H] Show Library loaning history [L] Show Loaned items [G] Show reserved items");

                ConsoleKey MemberInputKey = Console.ReadKey().Key;
                Console.WriteLine();

                switch (MemberInputKey)
                {
                    case ConsoleKey.B:
                        Console.Write("Please enter the itemId of the item you wish to borrow: ");
                        int id = int.Parse(Console.ReadLine());
                        
                        Member.Uitlenen(id);
                        break;
                    case ConsoleKey.H:
                        foreach (var item in Member.UItleenHistoriek)
                        {
                            int count = 1;
                            Console.WriteLine($"{count} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                            count++;
                        }
                        break;
                    case ConsoleKey.L:
                        foreach (var item in Member.ItemsUitgeleend)
                        {
                            int count = 1;
                            Console.WriteLine($"{count} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                            count++;
                        }
                        break;
                    case ConsoleKey.G:
                        foreach (var item in Member.Reservaties)
                        {
                            int count = 1;
                            Console.WriteLine($"{count} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                            count++;
                        }
                        break;
                    case ConsoleKey.O:
                        Member.ToonOverzicht(_Member);
                        break;
                    case ConsoleKey.R:
                        Console.Write("Please enter the itemId of the item you wish to return: ");
                        id = int.Parse(Console.ReadLine());

                        Member.Terugbrengen(id);
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Do you wish to search for an item by id(I) or title(T)?: ");
                        ConsoleKey searchKey = Console.ReadKey().Key;
                        if (searchKey == ConsoleKey.I)
                        {
                            Console.Write("What item do you wish to search for please enter an id: ");
                            id = int.Parse(Console.ReadLine());
                            Member.ZoekItemMetId(id);
                        }
                        else if (searchKey == ConsoleKey.T)
                        {
                            Console.Write("What item do you wish to search for please enter a title: ");
                            string title = Console.ReadLine();
                            Member.ZoekItemMetTitle(title);
                        }
                        
                        break;
                    default:
                        break;
                }
            }
            #endregion

            #region Menu Employee
            if (inputKey == ConsoleKey.E)
            {
                Console.WriteLine();
                Console.WriteLine("[S] Search for a specific item by id or title [O] Show items [B] Borrow an item [R] return an item [H] Show Library loaning history [L] Show Loaned items [G] Show reserved items [P] Promote Member to Employee");

                ConsoleKey EmployeeInputKey = Console.ReadKey().Key;
                Console.WriteLine();

                switch (EmployeeInputKey)
                {
                    case ConsoleKey.B:
                        Console.Write("Please enter the itemId of the item you wish to borrow: ");
                        int id = int.Parse(Console.ReadLine());

                        Employee.Uitlenen(id);
                        break;
                    case ConsoleKey.H:
                        foreach (var item in Employee.UItleenHistoriek)
                        {
                            int count = 1;
                            Console.WriteLine($"{count} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                            count++;
                        }
                        break;
                    case ConsoleKey.L:
                        foreach (var item in Employee.ItemsUitgeleend)
                        {
                            int count = 1;
                            Console.WriteLine($"{count} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                            count++;
                        }
                        break;
                    case ConsoleKey.G:
                        foreach (var item in Employee.Reservaties)
                        {
                            int count = 1;
                            Console.WriteLine($"{count} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                            count++;
                        }
                        break;
                    case ConsoleKey.O:
                        Employee.ToonOverzicht(_Employee);
                        break;
                    case ConsoleKey.R:
                        Console.Write("Please enter the itemId of the item you wish to return: ");
                        id = int.Parse(Console.ReadLine());

                        Employee.Terugbrengen(id);
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Do you wish to search for an item by id(I) or title(T)?: ");
                        ConsoleKey searchKey = Console.ReadKey().Key;
                        if (searchKey == ConsoleKey.I)
                        {
                            Console.Write("What item do you wish to search for please enter an id: ");
                            id = int.Parse(Console.ReadLine());
                            Employee.ZoekItemMetId(id);
                        }
                        else if (searchKey == ConsoleKey.T)
                        {
                            Console.Write("What item do you wish to search for please enter a title: ");
                            string title = Console.ReadLine();
                            Employee.ZoekItemMetTitle(title);
                        }
                        break;
                    case ConsoleKey.P:
                        Console.WriteLine("Please enter a first and lastname of a member to promote: ");
                        Console.Write("Firstname: ");
                        string memberFirstname = Console.ReadLine();
                        Console.Write("Lastname: ");
                        string memberLastname = Console.ReadLine();

                        _Employee.Add(Employee.PromoteToMember(memberFirstname, memberLastname, _Member));
                        break;
                    default:
                        break;
                }
            }
            #endregion
        }
    }
}
