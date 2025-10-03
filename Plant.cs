// Plant.cs
using System;

public class Plant
{

    public string kind { get; private set; }
    public int age { get; private set; }
    public int water { get; set; }
    public int height { get; private set; }

    public Plant()
    {
        kind = "Plant";
        age = 1;
        water = 0;
        height = 1;
    }

    public Plant(string kind, int age, int water, int height)
    {
        this.kind = string.IsNullOrWhiteSpace(kind) ? "Plant" : kind;
        this.age = (age < 1 || age > 1000) ? 1 : age;
        this.water = (water < 0 || water > 1) ? 0 : water;
        this.height = (height < 1 || height > 15) ? 1 : height;
    }

    public virtual void Print()
    {
        Console.WriteLine($"\nВид : {kind}");
        Console.WriteLine($"Возраст : {age} г.");
        Console.WriteLine($"Рост : {height} м");
        Console.WriteLine($"Полито растение? {(water == 1 ? "Да" : "Нет")}");
    }
}
