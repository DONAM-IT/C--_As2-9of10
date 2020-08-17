using MyBookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                choice = MyBookLibrary.MyListBook.Menu();
                switch (choice)
                {
                    case 1:
                        MyBookLibrary.MyListBook.AddNewBook();
                        break;
                    case 2:
                        MyBookLibrary.MyListBook.UpdateBook();
                        break;
                    case 3:
                        MyBookLibrary.MyListBook.DeleteBook();
                        break;
                    case 4:
                        MyBookLibrary.MyListBook.ListAllBook();
                        break;
                }
            } while (choice != 5);
        }
    }
}

