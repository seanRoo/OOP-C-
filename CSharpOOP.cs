using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Fido");
            Console.WriteLine("Name: " + dog.getName());
            dog.message();

            Rabbit bugs = new Rabbit("bugs");
            Console.WriteLine("Name: " + bugs.getName());
            bugs.message();
            bugs.food();

            Animal ani = new Dog("bengy");
            Console.WriteLine(ani.getName());
            

            Poly poly = new Poly();
            poly.print("Hello there");

            poly.print(2.4F);

            poly.print(87953735987);

            Console.ReadKey();



        }

        class Animal
        {
            String name;
            public Animal(String name)
            {
                setName(name);
            }
            public void setName(String name)
            {
                this.name = name;


            }
            public String getName()
            {
                return this.name;
            }
        }

        class Dog : Animal
        {

            public Dog(String name) : base(name)
            {

            }
            public void message()
            {
                Console.WriteLine("....And I go WOOF!!");
            }
        }

        class Rabbit : Animal
        {
            public Rabbit(String name) : base(name)
            {

            }
            public void message()
            {
                Console.WriteLine("Whats up doc...");
            }
            public void food()
            {
                Console.WriteLine("Knawing on a carrot...");
            }
        }


        class Poly
        {
            public void print(int i)
            {
                Console.WriteLine("Printing int: {0}", i);
            }
            public void print(string s)
            {
                Console.WriteLine("Printing string: {0}", s);

            }

            public void print(float f)
            {
                Console.WriteLine("Printing float: {0}", f);
            }

        }
    }
}
