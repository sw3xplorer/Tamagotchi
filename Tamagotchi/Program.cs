using Namespace;
Tamagotchi tama = new Tamagotchi();

Console.WriteLine("Please name your Tamagotchi:");
tama.name = Console.ReadLine();
Console.WriteLine($"Your Tamagotchi is now called: {tama.name}");

while(tama.GetAlive())
{
    tama.PrintStats();
    tama.Select();
    tama.Tick();
}

Console.WriteLine("Happy? You killed your Tamagotchi");

Console.ReadLine();