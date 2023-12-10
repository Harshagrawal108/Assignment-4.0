using System.Collections.Generic;
using System;

Que1Ass4:
Ans: -
using System;

public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Balance cannot be set to a negative value.");
            }
            else
            {
                balance = value;
            }
        }
    }

    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(1000);

        account.Balance = -500;

        account.Deposit(120);
        account.Withdraw(400);

        Console.WriteLine($"Final balance: {account.Balance:C}");
    }
}
Que2Ass4:
Ans: -
using System;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public string FullCarName
    {
        get
        {
            return $"{Make} {Model} {Year}";
        }
    }

    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }
    public void main(string[] args)
    {
        Car myCar = new Car("Toyota", "Camry", 2022);
        string carName = myCar.FullCarName;
        Console.WriteLine(carName);

    }
}
Que3Ass4:
Ans: -
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullUpperCaseName
    {
        get
        {
            return $"{FirstName} {LastName}".ToUpper();
        }
    }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    Person person = new Person("John", "Doe");
    string fullNameUpperCase = person.FullUpperCaseName;
    Console.WriteLine(fullNameUpperCase);

}
Que4Ass4:
Ans: -
using System;

public static class Logger
{
    public static void LogMessage(string message)
    {
        Console.WriteLine($"{DateTime.Now}: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger.LogMessage("This is a log message.");
        Logger.LogMessage("Another log message.");

    }
}
Que5Ass4:
Ans: -
using System;

public class CustomList<T>
{
    private T[] items;
    private int capacity;
    private int count;

    public CustomList(int initialCapacity)
    {
        if (initialCapacity <= 0)
            throw new ArgumentException("Initial capacity must be greater than zero.");

        capacity = initialCapacity;
        items = new T[capacity];
        count = 0;
    }

    public T this[int index]

    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index is out of range.");

            return items[index];
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index is out of range.");

            items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (count == capacity)
        {
            capacity *= 2;
            Array.Resize(ref items, capacity);
        }

        items[count] = item;
        count++;
    }

    public int Count => count;
}

class Program
{
    static void Main(string[] args)
    {
        CustomList<int> myList = new CustomList<int>(3);

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        Console.WriteLine($"Element at index 0: {myList[0]}");
        Console.WriteLine($"Element at index 1: {myList[1]}");
        Console.WriteLine($"Element at index 2: {myList[2]}");

        myList[1] = 99;
        Console.WriteLine($"Modified element at index 1: {myList[1]}");
    }
}
Que6Ass4:
Ans: -
using System;

public class SimpleStack<T>
{
    private T[] stack;
    private int top;

    public SimpleStack(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");

        stack = new T[capacity];
        top = -1;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index > top)
                throw new IndexOutOfRangeException("Index is out of range.");

            return stack[index];
        }
    }

    public void Push(T item)
    {
        if (top == stack.Length - 1)
        {
            Array.Resize(ref stack, stack.Length * 2);
        }

        stack[++top] = item;
    }

    public T Pop()
    {
        if (top == -1)
            throw new InvalidOperationException("Stack is empty.");

        T item = stack[top];
        top--;
        return item;
    }

    public int Count => top + 1;

    public bool IsEmpty => top == -1;
}

class Program
{
    static void Main(string[] args)
    {
        SimpleStack<int> stack = new SimpleStack<int>(3);

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine($"Count: {stack.Count}");
        Console.WriteLine($"Is Empty: {stack.IsEmpty}");

        Console.WriteLine($"Top element: {stack[stack.Count - 1]}");

        Console.WriteLine("Popping elements from the stack:");
        while (!stack.IsEmpty)
        {
            Console.WriteLine($"Popped: {stack.Pop()}");
        }
    }
}
Que7Ass4:
Ans: -
using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

public class Bookshelf
{
    private List<Book> books;

    public Bookshelf()
    {
        books = new List<Book>();
    }

    public Book this[string title]
    {
        get
        {
            return books.Find(book => book.Title == title);
        }
        set
        {
            Book existingBook = books.Find(book => book.Title == title);
            if (existingBook != null)
            {
                books.Remove(existingBook);
            }
            books.Add(value);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bookshelf shelf = new Bookshelf();

        shelf["The Great Gatsby"] = new Book("The Great Gatsby", "F. Scott Fitzgerald");
        shelf["To Kill a Mockingbird"] = new Book("To Kill a Mockingbird", "Harper Lee");
        shelf["1984"] = new Book("1984", "George Orwell");

        Book book1 = shelf["The Great Gatsby"];
        Book book2 = shelf["To Kill a Mockingbird"];
        Book book3 = shelf["1984"];

        Console.WriteLine($"Book 1: {book1.Title} by {book1.Author}");
        Console.WriteLine($"Book 2: {book2.Title} by {book2.Author}");
        Console.WriteLine($"Book 3: {book3.Title} by {book3.Author}");
    }
}
Que8Ass4:
Ans: -
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que8_Ass4
{

    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    class Program
    {
        static void Main(string[] args)
        {
            Season currentSeason = Season.Summer; // Change this to the current season

            switch (currentSeason)
            {
                case Season.Spring:
                    Console.WriteLine("It's springtime. Flowers are blooming.");
                    break;
                case Season.Summer:
                    Console.WriteLine("It's summertime. Enjoy the warm weather.");
                    break;
                case Season.Autumn:
                    Console.WriteLine("It's autumn. Leaves are falling.");
                    break;
                case Season.Winter:
                    Console.WriteLine("It's winter. Time for snow and hot cocoa.");
                    break;
                default:
                    Console.WriteLine("Invalid season.");
                    break;
            }
        }
    }
}
