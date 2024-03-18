using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ParallelProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();
            // Subscribe
            Publisher.MyDel += subscriber.Handle; // Can subscribe here
            Publisher.MyDel("test"); // Can NOT invoke here
            Publisher.MyDel = null; // Can NOT directly assign here
            // Publish
            publisher.Publish("hello");
            publisher.Publish("world");

            Console.ReadLine();
        }
    }
    // Publisher
    public class Publisher
    {
        // Custom delegate type
        public delegate void MyDelegate(string message);
        // Declare a delegate variable (event)
        public static event MyDelegate MyDel;
        // Method to raise the event
        public void Publish(string message)
        {
            MyDel(message);
        }
    }
    // Subscriber
    public class Subscriber
    {
        // Event Handler
        public void Handle(string message)
        {
            Console.WriteLine($"Subscriber received the event: {message}");
        }
    }
}

