using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary
{
    public class MyBookInfor
    {
        private string ID, Name, Publisher;
        private int Price;

        public MyBookInfor() { }

        public MyBookInfor(string id, string name, string publisher, int price)
        {
            ID = id;
            Name = name;
            Publisher = publisher;
            Price = price;
        }

        public string bookID
        {
            get { return ID; }
            set { ID = value; }
        }

        public string bookName
        {
            get { return Name; }
            set { Name = value; }
        }

        public string bookPublisher
        {
            get { return Publisher; }
            set { Publisher = value; }
        }

        public int bookPrice
        {
            get { return Price; }
            set { Price = value; }
        }

        public void Display()
        {
            Console.WriteLine("ID: {0}  -   Name: {1}   -   Publisher: {2}  -   Price: {3}", this.ID, this.Name, this.Publisher, this.Price);
        }
    }

    public class MyListBook
    {
        static List<MyBookInfor> ListBook = new List<MyBookInfor>();

        public static bool listWarn()
        {
            if (ListBook.Count == 0)
            {
                Console.WriteLine("     >> List is empty <<");
                return false;
            }
            return true;
        }
        public static int CheckID(string id)
        {
            for (int i = 0; i < ListBook.Count; i++)
            {
                if (id.CompareTo(ListBook[i].bookID) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int Menu()
        {
            int choice;
            string exit = "";
            do
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("     1. Add new book               ");
                Console.WriteLine("     2. Update a book              ");
                Console.WriteLine("     3. Delete a book              ");
                Console.WriteLine("     4. List all book              ");
                Console.WriteLine("     5. Quit                       ");
                choice = CheckInput.InputInt("Enter your Choose: ");
                if (choice < 1 || choice > 5) Console.WriteLine("Choice from 1 to 5");
                if (choice == 5)
                {
                    exit = CheckInput.InputString("Do you want exit? Y/N: ");
                }
            } while (choice < 1 || choice > 5 || (string.Compare(exit, "n", true) == 0 && choice == 5));
            return choice;
        }

        public static void AddNewBook()
        {
            string id, name, publisher;
            int price;
            id = CheckInput.InputString("Please input Book ID: ");
            if (MyListBook.CheckID(id) > -1)
            {
                Console.WriteLine("     >> ID was haved <<");
                return;
            }
            name = CheckInput.InputString("Please input Book Name: ");
            publisher = CheckInput.InputString("Please input Book Publisher: ");
            price = CheckInput.InputInt("Please input Book Price: ");
            ListBook.Add(new MyBookInfor(id, name, publisher, price));
            Console.WriteLine("     >> New book was added <<");

        }

        public static void UpdateBook()
        {
            string id, name, publisher;
            int price;
            if (MyListBook.listWarn() == false) return;
            id = CheckInput.InputString("Please input Book ID: ");
            if (MyListBook.CheckID(id) == -1)
            {
                Console.WriteLine("     >> ID does not exist <<");
                return;
            }
            name = CheckInput.InputString("Please input Book Name: ");
            publisher = CheckInput.InputString("Please input Book Publisher: ");
            price = CheckInput.InputInt("Please input Book Price: ");
            ListBook[CheckID(id)].bookID = id;
            ListBook[CheckID(id)].bookName = name;
            ListBook[CheckID(id)].bookPublisher = publisher;
            ListBook[CheckID(id)].bookPrice = price;
            Console.WriteLine("     >> Book was updated <<");
        }

        public static void DeleteBook()
        {
            string id;
            if (MyListBook.listWarn() == false) return;
            id = CheckInput.InputString("Please input Book ID: ");
            if (MyListBook.CheckID(id) == -1)
            {
                Console.WriteLine("     >> ID does not exist <<");
                return;
            }
            string ans = "";
            ans = CheckInput.InputString("Do you want delete this book? Y/N: ");
            if (string.Compare(ans, "n", true) == 0) return;
            else
            {
                ListBook.RemoveAt(CheckID(id));
                Console.WriteLine("     >> {0} book was deleted <<", id);
            }
        }

        public static void ListAllBook()
        {
            if (MyListBook.listWarn() == false) return;
            foreach (MyBookInfor listAll in ListBook)
            {
                listAll.Display();
            }
        }
    }

    public class CheckInput
    {
        public static string InputString(string msg)
        {
            string result;
            while (true)
            {
                Console.Write(msg);
                result = Console.ReadLine();
                if (result.Length == 0)
                {
                    Console.WriteLine("Please input value");
                }
                else return result;
            }
        }

        public static int InputInt(string msg)
        {
            string result;
            int num;
            while (true)
            {
                Console.Write(msg);
                int temp = 0;
                result = Console.ReadLine();
                if (result.Length == 0) Console.WriteLine("Please input value");
                else
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] < 47 || result[i] > 58)
                        {
                            temp = 1;
                            break;
                        }
                    }
                    if (temp == 1) Console.WriteLine("Just input integer value");
                    else return num = int.Parse(result);
                }
            }
        }
    }
}
