using System.Runtime.CompilerServices;

namespace Namespace;
public class Tamagotchi
{
    List<string> words = new List<string>();
    Random generator = new Random();
    int hunger = 0;
    int boredom = 0;
    bool alive = true;
    public string name;
    string choice;
    int attempts = 0;
    public void Feed()
    {
        if (hunger < 2)
        {
            hunger -= (2 - (2 - hunger));
        }
        else
        {
            hunger -= 2;
        }
        Console.WriteLine($"You fed {name}");
        Task.Delay(2000).Wait();
        Console.Clear();

    }

    public void Hi()
    {
        try
        {
            Console.WriteLine();
            Console.WriteLine(words[generator.Next(words.Count)]);
            Task.Delay(1000).Wait();
            Console.Clear();
        }
        catch
        {
            Console.WriteLine($"\nNo words. Head empty. (Try teaching {name} something.)");
            Task.Delay(3000).Wait();
            Console.Clear();
        }
    }

    public void Teach()
    {
        Console.WriteLine("Write a word to learn: ");
        string word = Console.ReadLine();
        words.Add(word);
        Console.WriteLine($"{name} has learned: {word}");
        ReduceBoredom();
        Task.Delay(3000).Wait();
        Console.Clear();
    }

    public void Tick()
    {
        hunger += 1;
        boredom += 1;
    }

    public void PrintStats()
    {
        Console.WriteLine($"\nHunger: {hunger}");
        Console.WriteLine($"Boredom: {boredom}");
        Console.WriteLine($"Alive: {GetAlive()}");

        Console.WriteLine("\nWhat do you wish to do?");
        Console.WriteLine($"\n1. Feed {name}");
        Console.WriteLine($"2. Teach {name} a new word or phrase");
        Console.WriteLine($"3. Greet {name}");
        Console.WriteLine("4. Do nothing");

    }

    public bool GetAlive()
    {
        if (hunger < 10 || boredom < 10)
        {
            return true;
        }
        else
        {
            alive = false;
            return false;
        }
    }

    void ReduceBoredom()
    {
        if (boredom < 3)
        {
            boredom -= (3 - (3 - boredom));
        }
        else
        {
            boredom -= 3;
        }
    }

    public void Select()
    {
        //I decided to add a reference to this
        choice = Console.ReadLine();
        while(choice != "1" && choice != "2" && choice != "3" && choice != "4")
        {
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                if(attempts < 8)
                {
                    Console.WriteLine("Write one of the possible options.");
                    choice = Console.ReadLine();
                    attempts++;
                }
                else if(attempts == 8)
                {
                    Console.WriteLine("You're an idiot");
                    Console.WriteLine("Write again.");
                    choice = Console.ReadLine();
                    attempts++;
                }
                else if(attempts >= 9)
                {
                    Console.WriteLine("You aren't strong");
                    Console.WriteLine("\nKeep trying. You can't break it");
                    choice = Console.ReadLine();
                    attempts++;
                }

            }
        }

        if(choice == "1")
            {
                Feed();
            }

            else if(choice == "2")
            {
                Teach();
            }

            else if(choice == "3")
            {
                Hi();
            }

            else if(choice == "4")
            {
                Console.WriteLine("You did nothing");
                Task.Delay(1000).Wait();
                Console.Clear();
            }
        choice = "";
    }
}
