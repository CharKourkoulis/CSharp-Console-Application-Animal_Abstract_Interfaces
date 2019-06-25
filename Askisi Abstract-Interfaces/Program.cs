using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Askisi_Abstract_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Animal> animalsList = new List<Animal>();


            Duck animal1 = new Duck("papia", 6.5);
            Tiger animal2 = new Tiger("Tiger", 80.4);

            animalsList.Add(animal1);
            animalsList.Add(animal2);

            Console.ForegroundColor = ConsoleColor.Yellow;


            animal1.Output();
            animal1.Eat.Invoke();
            animal1.Fly();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;

            animal2.Output();
            animal2.Run();
            animal2.Eat.Invoke();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            Predicate<Animal> Scale = (x) => x.Weight > 50;
            Action<Animal> Hunt = (x) => Console.WriteLine($"DONT HUNT THE {x.Name.ToUpper()}  !!!!!!");


            AnimalSize(animal1, Scale);
            AnimalSize(animal2, Scale);
            Hunt.Invoke(animal2);


       
           
        }

        public static void AnimalSize(Animal animal, Predicate<Animal> scale)
        {
            if (scale(animal))
            {
                Console.WriteLine($"{animal.Name}  is a big Animal!");
            }
            else
            {
                Console.WriteLine($"{animal.Name}  is a small Animal!");
            }
        }
    }




       


}

    interface IFly
    {
        void Fly();

        
    }


    interface IRun
    {
        void Run();
    }



    abstract class Animal 
    {

        public abstract string Name { get; set; }

        public abstract double Weight { get; set; }


        public Animal()
        {

        }

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract void Output();

        
        

        public Action Eat = () => Console.WriteLine("I Am Eating!!!");
       
    }



    class Duck : Animal ,IFly
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }

        

        public Duck(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }


        public override void Output()
        {
            Console.WriteLine($"I am {Name}");
        }


        public void Fly()
        {
            Console.WriteLine("I Can fly!");
        }

        
        
       
        
    }


    class Tiger : Animal, IRun
    {
        public override string Name { get; set; }
        public override double Weight { get; set ; }



        public Tiger(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }



        public void Run()
        {
            Console.WriteLine("I Can Run!");
        }

        public override void Output()
        {
            Console.WriteLine($"I am {Name}");
        }
    }




