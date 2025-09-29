// Plant.cs
using System;

public class Plant
{

    public string kind { get; private set; }
    public int age { get; private set; }
    public int water { get; set; }

    public Plant()
    {
        kind = "Plant";
        age = 1;
        water = 0;
    }

    public Plant(string kind, int age, int water)
    {
        this.kind = string.IsNullOrWhiteSpace(kind) ? "Plant" : kind;
        this.age = (age < 1 || age > 1000) ? 1 : age;
        this.water = (water < 0 || water > 1) ? 0 : water;
    }

    public virtual void Print()
    {
        Console.WriteLine($"\nВид : {kind}");
        Console.WriteLine($"Возраст : {age} г.");
    }
}
