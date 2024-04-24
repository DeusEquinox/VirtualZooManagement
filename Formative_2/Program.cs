using Formative_2;

class Program
{
	public static void Main()
	{
	//Creating 3 animals and placing them in a list
		List<Animals> AnimalList = new();

		Parrot parrot = new("Greg", 25);
		Lion lion = new("Mufasa", 10);
		Turtle turtle = new("Bob", 100);
		
		AnimalList.Add(parrot);
		AnimalList.Add(lion);
		AnimalList.Add(turtle);

		Console.WriteLine("Welcome to the Virtual Zoo");
		DisplayMenu(AnimalList);
	}

	public static void DisplayMenu(List<Animals> AL)
	{
		//Display the main menu and trigger a function based on user input
		Console.WriteLine(""""
			
			1. Display the animals 
			2. Feed the animals
			3. Move the animals
			4. Make the animals speak
			5. Put the animals to sleep
			6. Add an animal
			7. Exit
			"""");

		Console.Write("Enter your choice: ");
		string? choice = Console.ReadLine();

		switch (choice)
		{
			case "1":
				DisplayAnimals(AL);
				break;
			case "2":
				FeedAnimals(AL);
				break;
			case "3":
				MoveAnimals(AL);
				break;
			case "4":
				MakeAnimalsSpeak(AL);
				break;
			case "5":
				PutAnimalsToSleep(AL);
				break;
			case "6":
				AddAnimal(AL);
				break;
			case "7":
				Environment.Exit(0);
				break;
			default:
				Console.WriteLine("Invalid choice. Please try again.");
				break;
		}

		DisplayMenu(AL);
	}

	public static void DisplayAnimals(List<Animals> AL)
	{
		//Display the animals proprties
		Console.WriteLine("\nList of all the animals");
		for (int i = 0; i < AL.Count; i++)
		{
			AL[i].Display();
		}
	}

	public static void FeedAnimals(List<Animals> AL)
	{
		//Display animal properties
		DisplayAnimals(AL);
		Console.Write("Enter the NAME (not type) of the animal you want to feed: ");
		string? name = Console.ReadLine();

		//Checking for the user enered name within the list of animals
		for (int i = 0; i < AL.Count; i++)
		{
			if (AL[i].Name == name)
			{
				ChoiceCheck(AL, i);
				return;
			}
		}

		Console.WriteLine("Animal not found. Please try again.");
	}

	public static void ChoiceCheck(List<Animals> AL, int index)
	{
		//Showing the user what food they can feed the animal and letting them choose
		for (int i = 0; i < AL[index].Food.Count; i++)
		{
			Console.WriteLine(i + 1 + ". " + AL[index].Food[i]);
		}
		Console.Write($"What do you want to feed {AL[index].Name}: ");
		string? Food = Console.ReadLine();
		int FoodChoice;

		//Using overloading to allow the user to choose by entering the name of the food or the number on the list
		try
		{
			FoodChoice = Convert.ToInt32(Food);
			AL[index].Eat(AL[index].Food, FoodChoice);
		}
		catch (Exception)
		{
			AL[index].Eat(AL[index].Food, Food);
		}
	}

	public static void MoveAnimals(List<Animals> AL)
	{
		// Asking the user what animal they  want to move and where
		Console.Write("Enter the name of the animal you want to move: ");
		string? name = Console.ReadLine();

		Console.Write("Enter the location you want to move the animal to (Enclosure, Feeding area, Sleeping area): ");
		string? location = Console.ReadLine();

		for (int i = 0; i < AL.Count; i++)
		{
			if (AL[i].Name == name)
			{
				AL[i].Move(location);
				return;
			}
		}

		Console.WriteLine("Animal not found. Please try again.");
	}

	public static void MakeAnimalsSpeak(List<Animals> AL)
	{

		Console.Write("Enter the name of the animal you want to hear the sound off: ");
		string? name = Console.ReadLine();

		//Making the animal speak based on which animal the user chose
		for (int i = 0; i < AL.Count; i++)
		{
			if (AL[i].Name == name)
			{
				AL[i].Speak();
				return;
			}
		}
		Console.WriteLine("Animal not found. Please try again.");
	}

	public static void PutAnimalsToSleep(List<Animals> AL)
	{
		Console.Write("Enter the name of the animal you want make sleep: ");
		string? name = Console.ReadLine();

		//Making the animal sleep based on which one the user chose
		for (int i = 0; i < AL.Count; i++)
		{
			if (AL[i].Name == name)
			{
				AL[i].Sleep(AL, i);
				return;
			}
		}
		Console.WriteLine("Animal not found. Please try again.");
	}

	public static void AddAnimal(List<Animals> AL)
	{
		//Asking the user for the properties of the animals with error cheching
		Console.Write("Enter the name of the animal: ");
		string? name = Console.ReadLine();

		Console.Write("Enter the type of the animal (lion, parrot, turtle): ");
		string? type = Console.ReadLine();

		while (type.ToLower() is not "lion" and not "parrot" and not "turtle")
		{
			Console.Write("Please enter a valid type: ");
			type = Console.ReadLine();
		}

		Console.Write("Enter the age of the animal: ");
		int age = 0;
		while (age == 0)
		{
			try
			{
				age = Convert.ToInt32(Console.ReadLine());
			}
			catch (Exception)
			{
				Console.Write("Please enter a number: ");
			}
		}

		//Creating the animal based on the users properties
		if (type.Equals("Lion", StringComparison.CurrentCultureIgnoreCase))
		{
			AL.Add(new Lion(name, age));
			Console.WriteLine($"{name} the Lion has been added to the Zoo");
		}
		else if (type.Equals("Parrot", StringComparison.CurrentCultureIgnoreCase))
		{
			AL.Add(new Parrot(name, age));
			Console.WriteLine($"{name} the Parrot has been added to the Zoo");
		}
		else if (type.Equals("Turtle", StringComparison.CurrentCultureIgnoreCase))
		{
			AL.Add(new Turtle(name, age));
			Console.WriteLine($"{name} the Turtle has been added to the Zoo");
		}
	}	
}