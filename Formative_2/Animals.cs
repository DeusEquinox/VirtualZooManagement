using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formative_2
{

	interface IFeedable
	{
		void Eat(List<string> Foods, string food);
	}

	interface IMovable
	{
		void Move(string? location);
	}
	public class Animals : IMovable, IFeedable
	{
		public string? Name;
		public int Age;
		public string? Type;
		public string? Kind;
		public string? CurrentLocation;
		public List<string> Location = ["Enclosure", "Feeding area", "Sleeping area"];
		public List<string> Food = [];
		

		public Animals(string? name, int age)
		{
			this.Name = name;
			this.Age = age;

			//Assigning a food list based on what kind of animal diet it follows
			if (Type == "Carnivore")
			{
				List<string> Meat = ["Chicken", "Beef", "Pork", "Lamb"];
				Food.AddRange(Meat);
			}
			else if (Type == "Herbivore")
			{
				List<string> FruitAndVeg = ["Berries", "Apple", "Oranges", "Bananas"];
				Food.AddRange(FruitAndVeg);
			}
			else if (Type == "Omnivore")
			{
				List<string> AllFood = ["Chicken", "Beef", "Pork", "Lamb", "Berries", "Apple", "Oranges", "Bananas"];
				Food.AddRange(AllFood);
			}
		}

		public virtual void Display()
		{
			Console.WriteLine(Name + " the " + Kind + " is a " + Type + " and is " + Age + " years old.");
		}

		public void Eat(List<string> Foods, string food)
		{
			for (int i = 0; i < Foods.Count; i++)
			{
				if (Foods[i] == food)
				{
					Console.WriteLine(Name + " is being fed " + food);
					return;
				}
			}
			Console.WriteLine("We dont have that here. Please try again.");
		}

		public void Eat(List<string> Foods, int food)
		{
			while (food > Foods.Count)
			{
				Console.Write("Please choose one of the options from the list: ");
				try
				{
					food = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception)
				{
					Console.WriteLine("Please enter number");
				}
			}
			Console.WriteLine(Name + " is being fed " + Foods[food - 1]);
		}

		public void Sleep(List<Animals> AL, int i)
		{
			AL[i].CurrentLocation = "Sleeping area";
			Console.WriteLine(AL[i].Name + " is sleeping");
		}

		public virtual void Speak()
		{
			Console.WriteLine(Name + " makes animal noises");
		}

		public void Move(string? location)
		{
			if (Location.Contains(location))
			{
				CurrentLocation = location;
				Console.WriteLine("The animal is now in the " + CurrentLocation);
			}
			else
			{
				Console.WriteLine("Location not found. Please try again.");
			}
		}
	}

	class Lion : Animals
	{
		public Lion(string? name, int age) : base(name, age)
		{
			this.Kind = "Lion";
			this.Type = "Carnivore";

			List<string> Meat = ["Chicken", "Beef", "Pork", "Lamb"];
			Food.AddRange(Meat);
		}

		public override void Display()
		{
			Console.WriteLine(Name + " the Lion is a " + Type + " and is " + Age + " years old.");
		}

		public override void Speak()
		{
			Console.WriteLine("Roar");
		}
	}

	class Parrot : Animals
	{
		public Parrot(string? name, int age) : base(name, age)
		{
			this.Kind = "Parrot";
			this.Type = "Herbivore";

			List<string> FruitAndVeg = ["Berries", "Apple", "Oranges", "Bananas"];
			Food.AddRange(FruitAndVeg);
		}

		public override void Display()
		{
			Console.WriteLine(Name + " the Parrot is a " + Type + " and is " + Age + " years old.");
		}

		public override void Speak()
		{
			Console.WriteLine("Squawk");
		}
	}

	class Turtle : Animals
	{
		public Turtle(string? name, int age) : base(name, age)
		{
			this.Kind = "Turtle";
			this.Type = "Omnivore";

			List<string> AllFood = ["Chicken", "Beef", "Pork", "Lamb", "Berries", "Apple", "Oranges", "Bananas"];
			Food.AddRange(AllFood);
		}

		public override void Display()
		{
			Console.WriteLine(Name + " the Turtle is a " + Type + " and is " + Age + " years old.");
		}

		public override void Speak()
		{
			Console.WriteLine($"\n{Name} Croaks\n");
		}
	}
}
